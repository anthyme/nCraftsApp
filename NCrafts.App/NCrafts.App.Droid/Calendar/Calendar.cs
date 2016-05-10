using System;
using Android;
using Android.Content;
using Android.OS;
using Android.Provider;
using NCrafts.App.Business.Common.Calendar;
using NCrafts.App.Business.Sessions.Query;
using NCrafts.App.Droid.Calendar;
using Xamarin.Forms;

using static Java.Util.Calendar;
using CalendarEnum = Java.Util.CalendarField;
using CalendarsConst = Android.Provider.CalendarContract.Calendars.InterfaceConsts;
using JTimeZone = Java.Util.TimeZone;

[assembly: Dependency(typeof(Calendar))]
namespace NCrafts.App.Droid.Calendar
{
    public class Calendar : ICalendar
    {
        private readonly long calId = -1;
        private const int NcraftsColor = 544132;
        private bool _isAllow;
        private const string permissionCalendarRead = Manifest.Permission.ReadCalendar;
        private const string permissionCalendarWrite = Manifest.Permission.WriteCalendar;


        private void CalendarPermission()
        {
            if ((int)Build.VERSION.SdkInt < 23)
                _isAllow = true;
            else
            {
            }
        }


        // TODO: Check calendar may have some throwable errors
        public Calendar()
        {
            CalendarPermission();
            if (!_isAllow)
                return;

            var calendarsUri = CalendarContract.Calendars.ContentUri;
            string[] calendarsProjection =
            {
                CalendarsConst.Id,
                CalendarsConst.IsPrimary,
                CalendarsConst.AccountType
            };
            var cursor = Forms.Context.ContentResolver.Query(calendarsUri, calendarsProjection, null, null, null);
            while (cursor.MoveToNext())
            {
                var idIndex = cursor.GetColumnIndex(CalendarsConst.Id);
                var primaryIndex = cursor.GetColumnIndex(CalendarsConst.IsPrimary);
                var accountTypeIndex = cursor.GetColumnIndex(CalendarsConst.AccountType);
                if ((primaryIndex != -1 && cursor.GetString(primaryIndex) == "1") ||
                    (accountTypeIndex != -1 && cursor.GetString(accountTypeIndex) != "LOCAL" && cursor.GetString(1) == "1"))
                {
                    calId = cursor.GetLong(idIndex);
                    break;
                }
            }
        }

        private static long GetDateTimeMS(DateTime date)
        {
            var c = GetInstance(JTimeZone.Default);

            c.Set(CalendarEnum.DayOfMonth, date.Day);
            c.Set(CalendarEnum.HourOfDay, date.Hour);
            c.Set(CalendarEnum.Minute, date.Minute);
            c.Set(CalendarEnum.Month, date.Month - 1);
            c.Set(CalendarEnum.Year, date.Year);
            return c.TimeInMillis;
        }

        public void SetSessionInCalendar(SessionCalendar session)
        {
            if (!_isAllow || calId == -1)
                return;
            var eventValues = new ContentValues();

            eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId, calId);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Title, session.Title);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Description, session.Description);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS(session.Date.StartDate));
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS(session.Date.EndDate));
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventColor, NcraftsColor);
            var uri = Forms.Context.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
            // TODO: handle if uri is not set upper than 0, normally error
        }

        public void DeleteSessionInCalendar(SessionCalendar session)
        {
            if (!_isAllow || calId == -1)
                return;
            var eventUri = CalendarContract.Events.ContentUri;
            string[] eventsProjection =
            {
                CalendarContract.Events.InterfaceConsts.Id,
                CalendarContract.Events.InterfaceConsts.Deleted,
                CalendarContract.Events.InterfaceConsts.Title,
                CalendarContract.Events.InterfaceConsts.EventColor,
                CalendarContract.Events.InterfaceConsts.CustomAppUri
            };

            var cursor2 = Forms.Context.ContentResolver.Query(eventUri, eventsProjection, $"calendar_id={calId}", null, null);
            while (cursor2.MoveToNext())
            {
                if (cursor2.GetString(cursor2.GetColumnIndexOrThrow(CalendarContract.Events.InterfaceConsts.Title)) == session.Title &&
                    cursor2.GetInt(cursor2.GetColumnIndexOrThrow(CalendarContract.Events.InterfaceConsts.EventColor)) == NcraftsColor)
                {
                    var eventUriMaybe = ContentUris.WithAppendedId(eventUri, cursor2.GetLong(cursor2.GetColumnIndexOrThrow(CalendarContract.Events.InterfaceConsts.Id)));
                    Forms.Context.ContentResolver.Delete(eventUriMaybe, null, null);
                    // TODO: Check the result of the delete request
                }
            }
        }
    }
}
