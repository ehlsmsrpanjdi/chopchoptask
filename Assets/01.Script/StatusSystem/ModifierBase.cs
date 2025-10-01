using UnityEngine;

public class ModifierBase<T>
{
    public T Value { get; protected set; }

    public ModifierBase(T _Value)
    {
        Value = _Value;
    }


    public virtual T GetValue(T _Value)
    {
        return _Value;
    }
}
