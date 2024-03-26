using System;

public class ReactiveProperty<T>
{
    public event Action<T> OnChanged;

    private T _value;
    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }

    public ReactiveProperty(T value = default) => Value = value;

    // public static implicit operator T(ReactiveProperty<T> property) => property.Value;
    // public static implicit operator ReactiveProperty<T>(T value) => new(value);
}