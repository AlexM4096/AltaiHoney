using Flyweight;
using UnityEngine;

namespace ItemSystem
{
    [CreateAssetMenu(menuName = "Item System/Create ItemSettings")]
    public class ItemSettings : FlyweightSettings<Item, ItemSettings>
    {
        
    }
}