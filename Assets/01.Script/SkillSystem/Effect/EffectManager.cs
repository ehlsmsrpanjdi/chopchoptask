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

    Dictionary<int, EffectBase> effectDictionary= new Dictionary<int, EffectBase>();

    void Init()
    {
        effectDictionary.Add(1, new AttackEffect());
    }
}
