using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Script.Generic.Scheduler
{
    /// <summary> 스케줄 이벤트 객체 </summary>
    public class ScheduledEvent
    {
        public Guid Id { get; private set; }
        public Func<UniTask> Callback;
        public float Interval;
        public float NextGameTime;
        public DateTime NextRealTime;
        public bool Repeat;
        public bool Canceled;
        public TimeMode TimeMode;

        public ScheduledEvent(Func<UniTask> callback, float interval, bool repeat, TimeMode timeMode)
        {
            Id = Guid.NewGuid();

            Callback = callback;
            Interval = interval;
            Repeat = repeat;
            Canceled = false;
            TimeMode = timeMode;
            

            if (timeMode == TimeMode.RealTime)
            {
                NextRealTime = DateTime.UtcNow + TimeSpan.FromSeconds(interval);
            }
            else
            {
                float now = TimeMode == TimeMode.Scaled ? Time.time : Time.unscaledTime;
                NextGameTime = now + Interval;
            }
        }

        public void ReSchedule()
        {
            if (Repeat == false) return;

            if (TimeMode == TimeMode.RealTime)
            {
                NextRealTime = DateTime.UtcNow + TimeSpan.FromSeconds(Interval);
            }
            else
            {
                float now = TimeMode == TimeMode.Scaled ? Time.time : Time.unscaledTime;
                NextGameTime = now + Interval;
            }
        }

        public bool IsExecute()
        {
            bool check = TimeMode switch
            {
                TimeMode.Scaled => Time.time >= NextGameTime,
                TimeMode.UnScaled => Time.unscaledTime >= NextGameTime,
                TimeMode.RealTime => DateTime.UtcNow >= NextRealTime,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            Debug.Log(check);
            return check;
        }
    }
}