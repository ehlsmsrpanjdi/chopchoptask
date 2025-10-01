using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
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

    Dictionary<int, SkillData> ownedSkillDictionary = new Dictionary<int, SkillData>();

    List<SkillData> equipmentSkillList = new List<SkillData>();

    List<float> coolTimeList = new List<float>();
    //List<int> equipmentSkillIndexList = new List<int>();

    public float GetSkillCoolTime(int _index)
    {
        if (coolTimeList.Count <= _index)
        {
            return 0f;
        }
        else
        {
            return coolTimeList[_index];
        }
    }

    public SkillData GetEquipmentSkillData(int _index)
    {
        if(equipmentSkillList.Count <= _index)
        {
            return null;
        }
        else
        {
            return equipmentSkillList[_index];
        }
    }

    public void SelectSkill(int _SkillID)
    {
        SkillData data = SkillDataManager.Instance.GetSkillData(_SkillID);

        //SkillData data = ownedSkillDictionary[_SkillID];
        coolTimeList.Add(0);
        equipmentSkillList.Add(data);
    }

    public void UnSelectSkill(int _SkillIndex)
    {
        equipmentSkillList.RemoveAt(_SkillIndex);
        coolTimeList.RemoveAt(_SkillIndex);
    }

    public void Update(float _Deltatime)
    {
        for (int i = 0; i < coolTimeList.Count; ++i)
        {
            if (coolTimeList[i] > 0f)
            {
                coolTimeList[i] -= _Deltatime;
                if (coolTimeList[i] < 0f)
                {
                    coolTimeList[i] = 0;
                }
            }
        }
    }

    public SkillBase ExcuteSkill()
    {
        for (int i = 0; i < coolTimeList.Count; ++i)
        {
            SkillData data = equipmentSkillList[i];
            if (-1 != data.skillCondition)
            {
                if (false == SkillConditionContainer.Instance.CheckCondition(data.skillCondition, data.damageRatio))
                {
                    continue;
                }
            }
            if (coolTimeList[i] <= 0)
            {
                coolTimeList[i] = equipmentSkillList[i].coolTime;
                UIManager.Instance.GetUI<SkillUI>().SkillUse(i);
                return SpawnSkill(i);
            }
        }
        return null;
    }
    public SkillBase SpawnSkill(int _SkillIndex)
    {
        SkillData data = equipmentSkillList[_SkillIndex];
        GameObject skillObj = ResourceManager.Instance.GetOnLoadedResource("Skill/Skill_" + data.skillID);
        GameObject spawnedObj = MonoBehaviour.Instantiate(skillObj);
        SkillBase spawnedSkill = spawnedObj.GetComponent<SkillBase>();

        spawnedSkill.Init(data);
        return spawnedSkill;
    }

    public SkillBase SpawnNormalSkill()
    {
        SkillData data = SkillDataManager.Instance.GetSkillData(0);
        GameObject skillObj = ResourceManager.Instance.GetOnLoadedResource("Skill/Skill_" + data.skillID);
        GameObject spawnedObj = MonoBehaviour.Instantiate(skillObj);
        SkillBase spawnedSkill = spawnedObj.GetComponent<SkillBase>();

        spawnedSkill.Init(data);
        return spawnedSkill;
    }
}
