using System;

namespace NCrafts.App.Business.Common
{
    public class TimeSlot
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsOverlap(TimeSlot timeSlot)
        {
            return (StartDate.Ticks > timeSlot.StartDate.Ticks && StartDate.Ticks < timeSlot.EndDate.Ticks) ||
                   (EndDate.Ticks > timeSlot.StartDate.Ticks && EndDate.Ticks < timeSlot.EndDate.Ticks) ||
                   (timeSlot.StartDate.Ticks > StartDate.Ticks && timeSlot.StartDate.Ticks < EndDate.Ticks) ||
                   (StartDate.Ticks == timeSlot.StartDate.Ticks && EndDate.Ticks == timeSlot.EndDate.Ticks);
        }
    }
}