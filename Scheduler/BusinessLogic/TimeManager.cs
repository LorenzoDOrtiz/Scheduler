using System;

namespace Scheduler.BusinessLogic
{
    internal class TimeManager
    {
        public static string GetStartTime(DateTime startDate, DateTime startTime)
        {
            var start = startDate.ToString("yyyy-MM-dd") + " " + startTime.ToString("HH:mm:ss");
            return start;
        }

        public static string GetEndTime(DateTime endDate, DateTime endTime)
        {
            var end = endDate.ToString("yyyy-MM-dd") + " " + endTime.ToString("HH:mm:ss");
            return end;
        }
    }
}
