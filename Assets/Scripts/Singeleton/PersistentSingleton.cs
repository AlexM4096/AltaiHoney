using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : Component 
{
    public bool AutoUnParentOnAwake { get; protected set; } = true;

    private static T _instance;

    public static bool HasInstance => _instance != null;
    public static bool TryGetInstance(out T instance)
    {
        instance = _instance;
        return HasInstance;
    }

    public static T Instance 
    {
        get 
        {
            if (HasInstance) return _instance;
                
            _instance = FindAnyObjectByType<T>();
            if (HasInstance) return _instance;
                
            var go = new GameObject($"{typeof(T).Name} (Auto-Generated)");
            _instance = go.AddComponent<T>();

            return _instance;
        }
        protected set => _instance = value;
    }
        
    protected virtual void Awake() 
    {
        InitializeSingleton();
    }

    protected virtual void InitializeSingleton() 
    {
        if (!Application.isPlaying) return;

        if (AutoUnParentOnAwake) 
            transform.SetParent(null);

        if (!HasInstance) 
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        } 
        else 
        {
            if (_instance != this)
                Destroy(gameObject);
        }
    }
}