using System;
using TMPro;
using UnityEngine;

namespace Timer
{
    public class TimerTest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textElement;
        [SerializeField, Range(0, 10)] private float acceleration;
        private EditableCountdown _timer;

        private void Awake()
        {
            _timer = new EditableCountdown(this, 60);
            _timer.Start();
        }

        private void Update()
        {
            TimeSpan time = TimeSpan.FromSeconds(_timer.CurrentTime);
            textElement.text = time.ToString(@"mm\:ss\:fff");
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _timer?.ChangeAcceleration(acceleration);
        }
#endif
    }
}