using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component 
{
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

        _instance = this as T;
    }
}