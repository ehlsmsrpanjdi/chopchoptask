using UnityEngine;

public class Monster : Entitiy
{
    public MonsterTypeEnum monsterType = MonsterTypeEnum.Normal;

    BossUI bossUI;

    private void FixedUpdate()
    {
        if (true == Player.Instance.isRunning)
        {
            transform.position = transform.position + new Vector3(-Time.deltaTime * Player.Instance.playerBuf.moveSpeed.GetValue(StageManager.moveSpeed), 0, 0);
        }
    }

    private void Start()
    {
        if (MonsterTypeEnum.Boss == monsterType)
        {
            bossUI = UIManager.Instance.GetUI<BossUI>();
            StageManager instance = StageManager.Instance;
            instance.currentBossTime = 20f;
            bossUI.OnUI();
            bossUI.SetTimerRatio(instance.currentBossTime / instance.bossTime);
        }
    }


    private void Update()
    {
        if (MonsterTypeEnum.Boss == monsterType)
        {
            StageManager instance = StageManager.Instance;
            instance.currentBossTime -= Time.deltaTime;
            float ratio = instance.currentBossTime / instance.bossTime;
            if (ratio < 0)
            {
                GameManager.Instance.DebugStageFail();
                bossUI.OffUI();
                monsterType = MonsterTypeEnum.None;
                return;
            }
            bossUI.SetTimerRatio(instance.currentBossTime / instance.bossTime);
        }
    }

    public override bool TakeDamage(float _Damage)
    {
        bool damagedResult = base.TakeDamage(_Damage);
        if (MonsterTypeEnum.Boss == monsterType)
        {
            bossUI.SetHpRatio(GetHPRatio());
        }
        return damagedResult;
    }

    private void OnDestroy()
    {
        if (MonsterTypeEnum.Boss == monsterType)
        {
            if (bossUI != null)
            {
                bossUI.OffUI();
            }
            StageManager.Instance.StageClear();
        }
        int goldAmount = (int)entityHP / 10;
        Player.Instance.GainGold(goldAmount);
    }

    public void StatMultiplier(float _Ratio)
    {
        entityAttack *= _Ratio;
        entityCurrentHP *= _Ratio;
        entityHP *= _Ratio;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
