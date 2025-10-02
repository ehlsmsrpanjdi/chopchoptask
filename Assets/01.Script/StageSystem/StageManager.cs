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

    public static float moveSpeed = 10f;

    public int currentStage = 1;

    public int completeStage = 1;

    bool stageStart = false;

    public float monsterSpawnLength = 20f;

    public float bossTime = 20f;
    public float currentBossTime = 20f;

    Vector3 monsterSpawnPoint = new Vector3(20.0f, 0.0f, 0.0f);

    public void StageStart()
    {
        stageStart = false;
        Player.Instance.SetState(StateEnum.Run);
    }

    public void NextStage()
    {
        ++currentStage;
    }

    public void StageClear()
    {
        completeStage = currentStage;
    }

    public void StageFail()
    {
        --currentStage;

    }

    public void Spawn()
    {
        if (false == stageStart)
        {
            if (completeStage < currentStage)
            {
                currentBossTime = 20f;
                SpawnBoss();
            }
            else
            {
                SpawnMonster();
            }
            stageStart = true;
            return;
        }
        SpawnMonster();
    }


    public void SpawnMonster()
    {
        int currentStageMonsterInfo = StageMonsterInfo.Instance.GetCertainStageMonsterTable(currentStage);
        GameObject monsterInfo = null;
        for (int i = 0; i < 5; ++i)
        {
            monsterInfo = StageMonsterInfo.Instance.GetMonsterData(currentStageMonsterInfo);
            GameObject spawnedMonster = MonoBehaviour.Instantiate(monsterInfo);
            spawnedMonster.transform.position = monsterSpawnPoint + Vector3.right * i * 1.5f;
            spawnedMonster.GetComponent<Monster>().StatMultiplier(currentStage);
        }
    }

    public void SpawnBoss()
    {
        int currentBossInfo = StageMonsterInfo.Instance.GetCertainBossMonsterTable(currentStage);

        GameObject monsterInfo = null;

        monsterInfo = StageMonsterInfo.Instance.GetMonsterData(currentBossInfo);
        GameObject spawnedMonster = MonoBehaviour.Instantiate(monsterInfo);
        spawnedMonster.transform.position = monsterSpawnPoint + Vector3.right;
        spawnedMonster.transform.localScale = Vector3.one * 3;

        Monster currentMonster = spawnedMonster.GetComponent<Monster>();
        currentMonster.StatMultiplier(currentStage * 10);

        currentMonster.monsterType = MonsterTypeEnum.Boss;
    }
}
