using System.Collections.Generic;


/// <summary>
/// 실제 스킬 데이터
/// </summary>
public class SkillData
{
    public int skillID;
    public float damageRatio; //뎀지 비율
    public int hitCount;  // 타수 몇 명 때릴지에 대한임
    public float hitInterval;  // 타수 몇 번 때릴 지에 대한
    public skillEnum skillType;
    public int effectID;
    public float coolTime;
    public int skillCondition;

    public SkillData(int skillID, float damageRatio, int hitCount, float hitInterval, int effectID, float coolTime, skillEnum skillEnum, int skillConditionValue = -1)
    {
        this.skillID = skillID;
        this.damageRatio = damageRatio;
        this.hitCount = hitCount;
        this.hitInterval = hitInterval;
        this.skillType = skillEnum;
        this.effectID = effectID;
        this.coolTime = coolTime;
        this.skillCondition = skillConditionValue;
    }
}

public class SkillDataManager
{
    static SkillDataManager instance;

    public static SkillDataManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new SkillDataManager();
                instance.Init();
            }
            return instance;
        }
    }

    Dictionary<int, SkillData> data = new Dictionary<int, SkillData>();

    void Init()
    {
        //  스킬 ID, 스킬 데미지 비율, 몇 번 때리는가, 타수가 있는가, 쿨타임, 어떤 타입의 스킬인지
        data.Add(0, new SkillData(0, 100, 1, 1, 1, 0, skillEnum.Attack)); // temp Data고 나중에 excel화 시킬거임
        data.Add(1, new SkillData(1, 300, 2, 4, 1, 3, skillEnum.Attack));  // 300% 데미지, 2명 때리고, 인당 4타, 1번 이펙트 사용, 쿨타임 3
        data.Add(2, new SkillData(2, 30, 1, 1, 2, 3, skillEnum.Heal, 1));  // 30% 효과, 1번 동작, 횟수 1회, 2번 이펙트 사용,  쿨타임 3, 회복타입
        data.Add(3, new SkillData(3, 1.3f, 10, 1, 4, 15, skillEnum.Passive));  // 130% 효과, 10초 동작, 횟수 1회, 4번 이펙트 사용, 15초 쿨타임, 페시브 타입
    }

    public Dictionary<int, SkillData> GetAllSkillData()
    {
        return data;
    }

    public SkillData GetSkillData(int skillID)
    {
        if (true == data.ContainsKey(skillID))
        {
            return data[skillID];
        }
        else
        {
            LogHelper.LogWarrning("없는 스킬id가 들어옴");
            return null;
        }
    }
}