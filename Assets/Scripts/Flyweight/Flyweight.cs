using Attributes;
using UnityEngine;

namespace Flyweight
{
    public abstract class Flyweight<TFlyweight, TSettings> : MonoBehaviour
        where TFlyweight : Flyweight<TFlyweight, TSettings>
        where TSettings : FlyweightSetting<TFlyweight, TSettings>
    {
        [field:SerializeField] [field:HideInPlay]
        public TSettings Setting { get; private set; }

        public void Initialize(TSettings settings)
        {
            Setting = settings;
        }

        public void Destroy() => Setting.Release(this as TFlyweight);
    }
}