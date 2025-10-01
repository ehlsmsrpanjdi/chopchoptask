using System.Collections.Generic;

public class EffectManager
{
    static EffectManager instance;

    public static EffectManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new EffectManager();
                instance.Init();
            }
            return instance;
        }
    }

    Dictionary<int, EffectBase> effectDictionary = new Dictionary<int, EffectBase>();

    void Init()
    {
        effectDictionary.Add(1, new AttackEffect());
        effectDictionary.Add(2, new HealEffect());
        effectDictionary.Add(3, new PassiveAttackEffect());
        effectDictionary.Add(4, new PassiveMoveSpeedEffect());
        effectDictionary.Add(5, new PassiveAttackSpeedEffect());
    }

    public EffectBase GetEffect(int effectId)
    {
        return effectDictionary[effectId];
    }
}
