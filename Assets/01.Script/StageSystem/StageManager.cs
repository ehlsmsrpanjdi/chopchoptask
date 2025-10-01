using System.Collections.Generic;
using UnityEngine;

public class StageManager
{
    static StageManager instance;


    public static StageManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new StageManager();
            }
            return instance;
        }
    }

    public static float moveSpeed = 3.0f;

    public int currentStage = 1;

    public float monsterSpawnLength = 10f;

    Vector3 monsterSpawnPoint = new Vector3(20.0f, 0.0f, 0.0f);

    public void StageStart()
    {
        Player.Instance.SetState(StateEnum.Run);
    }

    public void NextStage()
    {

    }

    public void EndState()
    {
    }

    public void SpawnMonster()
    {
        List<int> currentStageMonsterInfo = StageMonsterInfo.Instance.GetCertainStageMonsterTable(currentStage);
        GameObject monsterInfo = null;
        for (int i = 0; i < currentStageMonsterInfo.Count; ++i)
        {
            monsterInfo = StageMonsterInfo.Instance.GetMonsterData(currentStageMonsterInfo[i]);
            GameObject spawnedMonster = MonoBehaviour.Instantiate(monsterInfo);
            spawnedMonster.transform.position = monsterSpawnPoint + Vector3.right * i;
        }
    }
}
