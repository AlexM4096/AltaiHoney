using System;
using UnityEngine;

namespace Timer
{
    public class EditableCountdown : Countdown
    {
        private const float DefaultAcceleration = 1;
        private float _acceleration;

        public EditableCountdown(MonoBehaviour context, float time, float acceleration = DefaultAcceleration) : base(context, time)
        {
            _acceleration = acceleration;
        }

        public void Add(float time)
        {
            if (time < 0)
                throw new ArgumentException(nameof(time));

            if (!IsRunning) return;
            CurrentTime += time;
        }

        public void Subtract(float time)
        {
            if (time < 0)
                throw new ArgumentException(nameof(time));

            if (!IsRunning) return;
            CurrentTime -= time;

            if (CurrentTime >= 0) return;
            
            CurrentTime = 0;
            Stop();
        }

        public override void Reset()
        {
            base.Reset();
            _acceleration = DefaultAcceleration;
        }

        public override void Tick(float deltaTime)
        {
            base.Tick(deltaTime * _acceleration);
        }

        public void ChangeAcceleration(float acceleration)
        {
            if (acceleration < 0)
                throw new ArgumentException(nameof(acceleration));

            _acceleration = acceleration;
        }
    }
}