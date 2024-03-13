using System.Collections.Generic;
using ItemSystem;
using UnityEngine;

namespace HoneyExtractor
{
    [RequireComponent(typeof(Collider2D))]
    public class InputItemChecker : MonoBehaviour
    {
        [SerializeField] private List<ItemSettings> itemInputList;

        public bool HaveItem { get; private set; }

        public void UseItem() => HaveItem = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Item item)) return;
            if (!itemInputList.Contains(item.Setting)) return;
        
            item.Destroy();
            HaveItem = true;
        }
    }
}
