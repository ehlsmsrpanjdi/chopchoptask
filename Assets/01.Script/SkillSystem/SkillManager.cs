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

    List<SkillData> equipmentSkillList = new List<SkillData>() { null, null, null, null, null };

    List<float> coolTimeList = new List<float>() { 0, 0, 0, 0, 0 };
    //List<int> equipmentSkillIndexList = new List<int>();

    public void Reset()
    {
        for (int i = 0; i < equipmentSkillList.Count; ++i)
        {
            if (null != equipmentSkillList[i])
            {
                coolTimeList[i] = equipmentSkillList[i].coolTime;
            }
        }
    }

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
        if (equipmentSkillList.Count <= _index)
        {
            return null;
        }
        else
        {
            return equipmentSkillList[_index];
        }
    }

    //현재 장착중인 스킬이 아니라면 -1반환 맞으면 int반환
    public int IsEquipmentSkill(int _SkilID)
    {
        SkillData skillData = SkillDataManager.Instance.GetSkillData(_SkilID);

        for (int i = 0; i < equipmentSkillList.Count; ++i)
        {
            if (skillData == equipmentSkillList[i])
            {
                return i;
            }
        }
        return -1;
    }

    public void SelectSkill(int _SlotNumber, int _SkillID)
    {
        SkillData data = SkillDataManager.Instance.GetSkillData(_SkillID);
        coolTimeList[_SlotNumber] = data.coolTime;
        equipmentSkillList[_SlotNumber] = data;
    }

    public void UnSelectSkill(int _SkillIndex)
    {
        equipmentSkillList[_SkillIndex] = null;
        coolTimeList[_SkillIndex] = 0;
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
            if (null == data)
            {
                continue;
            }
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
