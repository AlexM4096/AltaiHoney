using UnityEngine;

namespace Timer
{
    public class Stopwatch : Timer
    {
        public Stopwatch(MonoBehaviour context) : base(context, 0) {}

        public override void Tick(float deltaTime)
        {
            CurrentTime += deltaTime;
        }
    }
}