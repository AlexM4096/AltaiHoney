using System;
using System.Collections;
using UnityEngine;

namespace Timer
{
    public abstract class Timer
    {
        private readonly MonoBehaviour _context;
        private IEnumerator _coroutine;
        
        protected float InitialTime;
        public float CurrentTime { get; protected set; }
        public bool IsRunning { get; protected set; }
        
        public float Progress => CurrentTime / InitialTime;
        
        public event Action OnTimerStart = delegate { };
        public event Action OnTimerStop = delegate { };

        protected Timer(MonoBehaviour context, float time)
        {
            _context = context;
            InitialTime = time;
        }

        public void Start()
        {
            if (IsRunning) return;

            Reset();
            StartTickRoutine();
            OnTimerStart.Invoke();
        }

        public void Stop()
        {
            StopTickRoutine();
            OnTimerStop.Invoke();
        }

        public void Pause() => StopTickRoutine();
        public void Resume() => StartTickRoutine();
        public virtual void  Reset() => CurrentTime = InitialTime;

        public abstract void Tick(float deltaTime);


        private void StartTickRoutine()
        {
            _coroutine = TickCoroutine();
            _context.StartCoroutine(_coroutine);
            IsRunning = true;
        }

        private void StopTickRoutine()
        {
            if (_coroutine == null) return;
            
            _context.StopCoroutine(_coroutine);
            IsRunning = false;
        }
        
        private IEnumerator TickCoroutine()
        {
            while (true)
            {
                Tick(Time.deltaTime);
                yield return null;
            }
        }

        public override string ToString()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(CurrentTime);
            return timeSpan.ToString(@"mm\:ss\:fff");
        }
    }
}