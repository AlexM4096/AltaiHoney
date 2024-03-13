using System;
using UnityEngine;

namespace Timer
{
    public class Countdown : Timer
    {
        public Countdown(MonoBehaviour context, float time) : base(context, time)
        {
            if (time <= 0)
                throw new ArgumentException(nameof(time));
        }

        public void Reset(float time)
        {
            InitialTime = time;
            Reset();
        }

        public override void Tick(float deltaTime)
        {
            CurrentTime -= deltaTime;

            if (CurrentTime >= 0) return;
            
            CurrentTime = 0;
            Stop();
        }
    }
}