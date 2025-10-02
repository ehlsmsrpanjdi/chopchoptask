using System.Collections.Generic;
using UnityEngine;

public class StageMonsterInfo
{
    static StageMonsterInfo instance;

    public static StageMonsterInfo Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new StageMonsterInfo();
                instance.Init();
            }
            return instance;
        }
    }

    Dictionary<int, GameObject> monsterTable = new Dictionary<int, GameObject>();

    Dictionary<int, int> monsterStageTable = new Dictionary<int, int>();

    Dictionary<int, int> bossStageTable = new Dictionary<int, int>();
    public void Init()
    {
        monsterTable.Add(1, ResourceManager.Instance.GetOnLoadedResource("Monster_1"));
        monsterTable.Add(2, ResourceManager.Instance.GetOnLoadedResource("Monster_2"));
        monsterTable.Add(3, ResourceManager.Instance.GetOnLoadedResource("Monster_3"));


        monsterStageTable.Add(1, 1);
        monsterStageTable.Add(2, 2);
        monsterStageTable.Add(3, 3);
        monsterStageTable.Add(4, 1);
        monsterStageTable.Add(5, 1);
        monsterStageTable.Add(6, 1);
        monsterStageTable.Add(7, 1);
        monsterStageTable.Add(8, 1);
        monsterStageTable.Add(9, 1);
        monsterStageTable.Add(10, 1);
        monsterStageTable.Add(11, 2);
        monsterStageTable.Add(12, 2);
        monsterStageTable.Add(13, 2);
        monsterStageTable.Add(14, 2);
        monsterStageTable.Add(15, 2);
        monsterStageTable.Add(16, 2);
        monsterStageTable.Add(17, 2);
        monsterStageTable.Add(18, 2);
        monsterStageTable.Add(19, 2);


        bossStageTable.Add(1, 1);
        bossStageTable.Add(2, 1);
        bossStageTable.Add(3, 1);
        bossStageTable.Add(4, 1);
        bossStageTable.Add(5, 3);
        bossStageTable.Add(6, 1);
        bossStageTable.Add(7, 1);
        bossStageTable.Add(8, 1);
        bossStageTable.Add(9, 3);
        bossStageTable.Add(10, 2);
        bossStageTable.Add(11, 2);
        bossStageTable.Add(12, 2);
        bossStageTable.Add(13, 2);
        bossStageTable.Add(14, 3);
        bossStageTable.Add(15, 2);
        bossStageTable.Add(16, 2);
        bossStageTable.Add(17, 2);
        bossStageTable.Add(18, 2);
        bossStageTable.Add(19, 3);
    }

    public GameObject GetMonsterData(int _MonsterID)
    {
        return monsterTable[_MonsterID];
    }

    public int GetCertainStageMonsterTable(int _StageInfo)
    {
        if (_StageInfo >= 20)
        {
            _StageInfo -= 19;
        }
        return monsterStageTable[_StageInfo];
    }

    public int GetCertainBossMonsterTable(int _StageInfo)
    {
        if (_StageInfo >= 20)
        {
            _StageInfo -= 19;
        }
        return bossStageTable[_StageInfo];
    }
}
