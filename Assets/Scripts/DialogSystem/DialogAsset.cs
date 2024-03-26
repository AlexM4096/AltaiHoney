using System;
using System.Collections.Generic;
using OrderSystem;
using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu(menuName = "Dialog System/Create Dialog")]
    public class DialogAsset : ScriptableObject, IDialog
    {
        [SerializeField] private List<string> lines;
        [SerializeField] private Optional<OrderData> orderDialog;

        public IReadOnlyList<string> Lines => lines;
        public OrderData OrderDialog { get; private set; }

        private void OnValidate()
        {
            if (!orderDialog.TryGetValue(out var value))
                value = new OrderData();

            OrderDialog = value;
        }
    }
}