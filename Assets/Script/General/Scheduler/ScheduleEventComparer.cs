using System.Collections.Generic;
using Script.Generic.Scheduler;
using UnityEngine;

public class ScheduleEventComparer : IComparer<ScheduledEvent>
{
    public int Compare(ScheduledEvent x, ScheduledEvent y)
    {
        // null 처리
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        
        return x.Canceled.CompareTo(y.Canceled);
    }
}
