using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSystem;
using UnityEngine;

namespace OrderSystem
{
    [Serializable]
    public class Order
    {
        [SerializeField] private List<Item> items;
        public IReadOnlyList<Item> Items => items;

        public Order(IEnumerable<Item> items)
        {
            this.items = new List<Item>(items);
        }

        public bool IsFinished => items.All(x => x.IsFinished);

        [Serializable]
        public struct Item
        {
            public ItemSettings item;
            
            public int currentAmount;
            public int neededAmount;
            
            public bool IsFinished => currentAmount >= neededAmount;

            public Item(ItemSettings item, int neededAmount)
            {
                this.item = item;
                this.currentAmount = 0;
                this.neededAmount = neededAmount;
            }

            public override string ToString()
                => $"{item.name} : {currentAmount} / {neededAmount}";
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"Order : {Items.Count}").Append("\t");

            foreach (var item in Items)
                stringBuilder.Append(item).Append("\t");

            return stringBuilder.ToString();
        }
    }
}