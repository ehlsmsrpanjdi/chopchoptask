using UnityEngine;

public class Monster : Entitiy
{
    public MonsterTypeEnum monsterType = MonsterTypeEnum.Normal;

    private void FixedUpdate()
    {
        if (true == Player.Instance.isRunning)
        {
            transform.position = transform.position + new Vector3(-Time.deltaTime * Player.Instance.playerBuf.moveSpeed.GetValue(StageManager.moveSpeed), 0, 0);
        }
    }

    private void OnDestroy()
    {
        if(MonsterTypeEnum.Boss == monsterType)
        {
            StageManager.Instance.StageClear();
        }
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
