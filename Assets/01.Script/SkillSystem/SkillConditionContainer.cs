using System;
using System.Collections.Generic;

public class SkillConditionContainer
{
    Dictionary<int, Func<float, bool>> skillConditionDictionary = new Dictionary<int, Func<float, bool>>();

    static SkillConditionContainer instance;

    public static SkillConditionContainer Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new SkillConditionContainer();
                instance.Init();
            }
            return instance;
        }
    }

    void Init()
    {
        skillConditionDictionary.Add(1, condition_1);
    }

    public bool CheckCondition(int _conditionIndex, float _skillValue)
    {
        if(true == skillConditionDictionary.ContainsKey(_conditionIndex))
        {
            return skillConditionDictionary[_conditionIndex](_skillValue);
        }
        return false;
    }

    bool condition_1(float SkillValue)
    {
        float skillValueRatio = SkillValue / 100f;
        return 1 >= Player.Instance.GetHPRatio() + skillValueRatio;
    }

}
