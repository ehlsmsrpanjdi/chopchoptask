using UnityEngine;

public class ModifierBase<T>
{
    public T Value { get; protected set; }

    public float bufTime = 0f;

    public ModifierBase(T _Value)
    {
        Value = _Value;
    }


    public virtual T GetValue(T _Value)
    {
        return _Value;
    }

    public bool Update(float _DeltaTime)
    {
        bufTime -= _DeltaTime;
        if (bufTime <= 0f)
        {
            return true;
        }
        return false;
    }
}


public class MultiModifier : ModifierBase<float>
{
    public MultiModifier(float _Value) : base(_Value)
    {
    }

    public override float GetValue(float _Value)
    {
        return Value * _Value;
    }
}