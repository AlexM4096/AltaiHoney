using System;
using UnityEngine;

[Serializable]
public struct Optional<T>
{
    [SerializeField] private bool enabled;
    [SerializeField] private T value;

    public bool Enabled => enabled;
    public T Value => value;

    public Optional(T initialValue)
    {
        enabled = true;
        value = initialValue;
    }

    public bool TryGetValue(out T v)
    {
        if (Enabled)
        {
            v = value;
            return true;
        }

        v = default;
        return false;
    }
}