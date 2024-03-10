using UnityEngine;

namespace Flyweight
{
    public class FlyweightHolder : Singleton<FlyweightHolder>
    {
        public static Transform Transform => Instance.transform;
    }
}