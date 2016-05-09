using System;

namespace NCrafts.App.Business.Common.Infrastructure
{
    public interface ITimeZoneInfoProvider
    {
        TimeZoneInfo Get();
    }
}
