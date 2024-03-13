using System;
using DragAndDrop;
using Timer;
using UnityEngine;

namespace HoneyExtractor
{
    public class Extacrtor : MonoBehaviour
    {
        [SerializeField] private DragRotation dragRotation;
        [SerializeField] private InputItemChecker inputItemChecker;

        [SerializeField] private float processingTime;
        [SerializeField] private float overProcessingTime;

        public Countdown ProcessingTimer;
        public Countdown OverProcessingTimer;

        private void Awake()
        {
            ProcessingTimer = new Countdown(this, processingTime);
            OverProcessingTimer = new Countdown(this, overProcessingTime);
        }

        public DragRotation DragRotation => dragRotation;
        public InputItemChecker InputItemChecker => inputItemChecker;
    }
}
