using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
    Dictionary<int, SkillData> skillDataDictionary = new Dictionary<int, SkillData>();

    static SkillManager instance;

    public static SkillManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new SkillManager();
            }
            return instance;
        }
    }

    public int selectedSkillID = 1;

    public void TestInit()
    {
        SkillData data = new SkillData();

        AttackEffect effect = new AttackEffect(1.0f, 1.0f, 1, skillEnum.Attack);

        data.skillID = 1;
        data.skillPrefab = ResourceManager.Instance.GetOnLoadedResource("SkillEffect");
        data.skillEffect = effect;

        skillDataDictionary.Add(data.skillID, data);
    }

    public SkillData GetSkillData(int _SkillID)
    {
        if (true == skillDataDictionary.TryGetValue(_SkillID, out SkillData Data))
        {
            return Data;
        }
        else
        {
            LogHelper.LogWarrning("없는 스킬 참조 : " + _SkillID);
            return null;
        }
    }

    public SkillBase SpawnSkill()
    {
        SkillData skillData = GetSkillData(selectedSkillID);

        GameObject obj = MonoBehaviour.Instantiate(skillData.skillPrefab);
        SkillBase baseSkill = obj.GetComponent<SkillBase>();
        baseSkill.skillEffect = skillData.skillEffect;
        return obj.GetComponent<SkillBase>();
    }
}
