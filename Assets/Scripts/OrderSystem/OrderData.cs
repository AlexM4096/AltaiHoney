using System;
using System.Collections.Generic;
using UnityEngine;

namespace OrderSystem
{
    [Serializable]
    public class OrderData
    {
        [SerializeField] private Order order;
        [SerializeField] private List<string> lines;

        public Order Order => order;
        public IReadOnlyList<string> Lines => lines;

        public OrderData()
        {
            order = new Order(new List<Order.Item>());
            lines = new List<string>();
        }

        public OrderData(Order order, List<string> lines)
        {
            this.order = order;
            this.lines = lines;
        }
    }
}