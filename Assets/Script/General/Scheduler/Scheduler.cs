using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine.Networking;

namespace Script.Generic.Scheduler
{
    public enum TimeMode
    {
        Scaled,
        UnScaled,
        RealTime,
    }
    
    public class Scheduler : MonoSingleton<Scheduler>
    {
        private PriorityQueue<ScheduledEvent> _queue;
        [ShowInInspector]
        private Dictionary<Guid, ScheduledEvent> _eventDic;
        private Dictionary<Guid, CancellationTokenSource> _tokenDic;

        private ScheduleEventComparer _comparer;
        
        protected override void Awake()
        {
            base.Awake();

            _comparer = new ScheduleEventComparer();
            _queue = new PriorityQueue<ScheduledEvent>(_comparer);
            _eventDic = new Dictionary<Guid, ScheduledEvent>();
            _tokenDic = new Dictionary<Guid, CancellationTokenSource>();
        }

        private void Update()
        {
            while (_queue.TryPeek(out var evt) && evt.IsExecute())
            {
                if (evt.Canceled)
                {
                    _queue.Dequeue();
                    continue;
                }

                Debug.Log("실행");
                _queue.Dequeue();
                RunEventAsync(evt).Forget();
            }
        }


        private async UniTaskVoid RunEventAsync(ScheduledEvent evt)
        {
            var cts = new CancellationTokenSource();
            _tokenDic.TryAdd(evt.Id, cts);
            
            try
            {
                await evt.Callback.Invoke().AttachExternalCancellation(cts.Token);

                if (evt.Repeat && evt.Canceled == false)
                {
                    evt.ReSchedule();
                    _queue.Enqueue(evt);
                }
                else
                {
                    _eventDic.Remove(evt.Id);
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Log($"{evt.Id} 이벤트 취소됨");
            }
            catch (Exception e)
            {
                Debug.Log($"{evt.Id} 이벤트 실행 오류 : {e}");
            }
            finally
            {
                _tokenDic.Remove(evt.Id);
            }
        }
        
        public Guid Schedule(Action callback, float interval, bool repeat = false, TimeMode timeMode = TimeMode.Scaled)
        {
            return Schedule(WarpAction(callback), interval, repeat, timeMode);
        }
        
        public Guid Schedule(Func<UniTask> callback, float interval, bool repeat = false, TimeMode timeMode = TimeMode.Scaled)
        {
            var scheduleEvent = new ScheduledEvent(callback, interval, repeat, timeMode);
            _queue.Enqueue(scheduleEvent);
            _eventDic.TryAdd(scheduleEvent.Id, scheduleEvent);
            return scheduleEvent.Id;
        }

        public bool Cancel(Guid id)
        {
            if (_eventDic.TryGetValue(id, out var evt))
            {
                evt.Canceled = true;
                _eventDic.Remove(id);

                if (_tokenDic.TryGetValue(id, out var cts))
                {
                    cts.Cancel();
                    _tokenDic.Remove(id);
                }

                return true;
            }

            return false;
        }
        
        private Func<UniTask> WarpAction(Action callback)
        {
            return () =>
            {
                callback?.Invoke();
                return UniTask.CompletedTask;
            };
        }
    }
}