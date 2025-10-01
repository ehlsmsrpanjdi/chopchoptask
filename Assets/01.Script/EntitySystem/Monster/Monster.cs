using UnityEngine;

public class Monster : Entitiy
{
    public MonsterTypeEnum monsterType = MonsterTypeEnum.Normal;

    private void FixedUpdate()
    {
        if (true == Player.Instance.isRunning)
        {
            transform.position = transform.position + new Vector3(-StageManager.moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void OnDestroy()
    {
        if(MonsterTypeEnum.Boss == monsterType)
        {
            StageManager.Instance.StageClear();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
