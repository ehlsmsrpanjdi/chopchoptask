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

    Dictionary<int, List<int>> monsterStageTable = new Dictionary<int, List<int>>();

    Dictionary<int, int> bossStageTable = new Dictionary<int, int>();
    public void Init()
    {
        monsterTable.Add(1, ResourceManager.Instance.GetOnLoadedResource("Monster_1"));


        monsterStageTable.Add(1, new List<int>() { 1, 1, 1 });
        monsterStageTable.Add(2, new List<int>() { 1, 1, 1, 1 });
        bossStageTable.Add(1, 1);
        bossStageTable.Add(2, 1);
    }

    public GameObject GetMonsterData(int _MonsterID)
    {
        return monsterTable[_MonsterID];
    }

    public List<int> GetCertainStageMonsterTable(int _StageInfo)
    {
        return monsterStageTable[_StageInfo];
    }

    public int GetCertainBossMonsterTable(int _StageInfo)
    {
        return bossStageTable[_StageInfo];
    }
}
