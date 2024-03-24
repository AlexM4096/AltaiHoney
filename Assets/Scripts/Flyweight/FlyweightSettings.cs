using UnityEngine;
using UnityEngine.Pool;

namespace Flyweight
{
    public abstract class FlyweightSettings<TFlyweight, TSettings> : 
        ScriptableObject, IObjectPool<TFlyweight>
        where TFlyweight : Flyweight<TFlyweight, TSettings>
        where TSettings : FlyweightSettings<TFlyweight, TSettings>
    {
        [SerializeField] private GameObject prefab;
        
        private IObjectPool<TFlyweight> _pool;

        private void OnEnable()
        {
            _pool = new ObjectPool<TFlyweight>(
                Create,
                OnGet,
                OnRelease,
                OnDestroyPoolObject
            );
        }

        private TFlyweight Create()
        {
            var go = Instantiate(prefab, FlyweightHolder.Transform);
            go.name = prefab.name;

            if (!go.TryGetComponent(out TFlyweight flyweight))
                flyweight = go.AddComponent<TFlyweight>();
            
            flyweight.Initialize(this);

            return flyweight;
        }
        
        private void OnGet(TFlyweight f) => f.gameObject.SetActive(true);
        private void OnRelease(TFlyweight f) => f.gameObject.SetActive(false);
        private void OnDestroyPoolObject(TFlyweight f) => Destroy(f.gameObject);

        public TFlyweight Get() => _pool.Get();
        public PooledObject<TFlyweight> Get(out TFlyweight v) => _pool.Get(out v);
        public void Release(TFlyweight element) => _pool.Release(element);
        public void Clear() => _pool.Clear();
        public int CountInactive => _pool.CountInactive;
        
        public static implicit operator TSettings(FlyweightSettings<TFlyweight, TSettings> settings)
            => (TSettings)settings;
    }
}