using System;
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


public class EffectDiscriptionFactory
{
    Dictionary<int, Func<SkillData, string>> effectDiscription = new Dictionary<int, Func<SkillData, string>>();

    static EffectDiscriptionFactory instance;

    public static EffectDiscriptionFactory Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new EffectDiscriptionFactory();
                instance.Init();
            }
            return instance;
        }
    }

    void Init()
    {
        effectDiscription.Add(1, Discription_1);
        effectDiscription.Add(2, Discription_2);
        effectDiscription.Add(3, Discription_3);
        effectDiscription.Add(4, Discription_4);
        effectDiscription.Add(5, Discription_5);
    }

    public string GetEffectDiscription(SkillData _Data)
    {
        return effectDiscription[_Data.effectID].Invoke(_Data);
    }

    string Discription_1(SkillData _SkillData)
    {
        int damage = (int)_SkillData.damageRatio;
        int coolTime = (int)_SkillData.coolTime;
        int attackCount = (int)_SkillData.hitCount;
        int attackInterval = (int)_SkillData.hitInterval;

        return $"Deals {damage} damage to {attackCount} targets, repeated {attackInterval} times.\nCooldown: {coolTime} sec.";
    }

    string Discription_2(SkillData _SkillData)
    {
        int damage = (int)_SkillData.damageRatio;
        int coolTime = (int)_SkillData.coolTime;

        return $"Heals {damage} HP.\nCooldown: {coolTime} sec.";
    }

    string Discription_3(SkillData _SkillData)
    {
        int damage = (int)_SkillData.damageRatio;
        int coolTime = (int)_SkillData.coolTime;
        int attackCount = (int)_SkillData.hitCount;

        return $"Increases attack power by {damage}. Duration: {attackCount} sec.\nCooldown: {coolTime} sec.";
    }

    string Discription_4(SkillData _SkillData)
    {
        int damage = (int)_SkillData.damageRatio;
        int coolTime = (int)_SkillData.coolTime;
        int attackCount = (int)_SkillData.hitCount;

        return $"Increases movement speed by {damage}. Duration: {attackCount} sec.\nCooldown: {coolTime} sec.";
    }

    string Discription_5(SkillData _SkillData)
    {
        int damage = (int)_SkillData.damageRatio;
        int coolTime = (int)_SkillData.coolTime;
        int attackCount = (int)_SkillData.hitCount;

        return $"Increases attack speed by {damage}. Duration: {attackCount} sec.\nCooldown: {coolTime} sec.";
    }
}