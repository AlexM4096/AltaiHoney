using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OrderSystem
{
    [Serializable]
    public class OrderGenerator
    {
        [SerializeField] private OrderSettings settings;

        public Order GenerateOrder()
        {
            int itemsInOrder = Random.Range(
                settings.MinItemsAmountInOrder,
                settings.MaxItemsAmountInOrder + 1);
            
            var items = settings.Items.ToList();
            items.Shuffle();
            items.RemoveRange(itemsInOrder, items.Count - itemsInOrder);

            var orderItems = new List<Order.Item>();
            foreach (var item in items)
            {
                int amount = Random.Range(item.minNeededAmount, item.maxNeededAmount);
                orderItems.Add(new Order.Item(item.item, amount));
            }

            return new Order(orderItems);
        }
    }
}