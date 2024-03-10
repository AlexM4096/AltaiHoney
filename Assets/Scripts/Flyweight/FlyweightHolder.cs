using UnityEngine;

namespace Flyweight
{
    public class FlyweightHolder : PersistentSingleton<FlyweightHolder>
    {
        public static Transform Transform => Instance.transform;
    }
}