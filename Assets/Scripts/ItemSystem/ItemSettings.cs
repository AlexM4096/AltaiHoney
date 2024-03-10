using Flyweight;
using UnityEngine;

namespace ItemSystem
{
    [CreateAssetMenu(menuName = "Flyweight/Create ItemSettings")]
    public class ItemSettings : FlyweightSetting<Item, ItemSettings>
    {
        
    }
}