using System;
using System.Collections.Generic;
using ItemSystem;
using UnityEngine;

namespace OrderSystem
{
    [CreateAssetMenu(menuName = "OrderSystem/Create OrderSettings")]
    public class OrderSettings : ScriptableObject
    {
        [SerializeField] private List<Item> items;

        [SerializeField] private int minItemsAmountInOrder;
        [SerializeField] private int maxItemsAmountInOrder;
        
        public IReadOnlyList<Item> Items => items;

        public int MinItemsAmountInOrder => minItemsAmountInOrder;
        public int MaxItemsAmountInOrder => maxItemsAmountInOrder;
        
        [Serializable]
        public struct Item
        {
            public ItemSettings item;
            public int minNeededAmount;
            public int maxNeededAmount;
        }
    }
}