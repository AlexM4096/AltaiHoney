using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using DragAndDrop;
using ItemSystem;
using Timer;
using UnityEngine;

namespace HoneyExtractor
{
    public class Extacrtor : MonoBehaviour
    {
        [SerializeField] private DragRotation dragRotation;
        [SerializeField] private InputItemChecker inputItemChecker;
        [SerializeField] private Clicky clicky;

        [SerializeField] private float processingTime;
        [SerializeField] private float overProcessingTime;

        [SerializeField] private SerializedDictionary<ItemSettings, Transform> dictionary;

        public IReadOnlyDictionary<ItemSettings, Transform> Dictionary => dictionary;

        public Countdown ProcessingTimer;
        public Countdown OverProcessingTimer;
        
        public DragRotation DragRotation => dragRotation;
        public InputItemChecker InputItemChecker => inputItemChecker;
        public Clicky Clicky => clicky;

        private void Awake()
        {
            ProcessingTimer = new Countdown(this, processingTime);
            OverProcessingTimer = new Countdown(this, overProcessingTime);
        }
    }
}
