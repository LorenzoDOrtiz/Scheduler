using System;

namespace Scheduler.BusinessLogic
{
    internal class TimeManager
    {
        internal static DateTime GetStartTime(DateTime startDate, DateTime startTime)
        {
            DateTime.TryParse(startDate.ToString("yyyy-MM-DD") + " " + startTime.ToString("HH:mm:ss"), out DateTime start);
            return start;
        }

        internal static DateTime GetEndTime(DateTime endDate, DateTime endTime)
        {
            DateTime.TryParse(endDate.ToString("yyyy-MM-DD") + " " + endTime.ToString("HH:mm:ss"), out DateTime end);
            return end;
        }
    }
}
