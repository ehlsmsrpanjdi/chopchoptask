using UnityEngine;

public class Player : Entitiy
{
    private Player()
    {

    }

    static Player instance;

    public static Player Instance
    {
        get
        {
            return instance;
        }
    }

    public bool isRunning { get; private set; }
    Entitiy selectedMonster = null;
    float runningLength = 0f;
    public ModifierStat playerBuf = new ModifierStat();

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        entityCurrentHP = 30f;
        hpBar.SetFill(entityCurrentHP / entityHP);
    }


    private void Update()
    {
        float frameTime = Time.deltaTime;

        if (true == isRunning)
        {
            runningLength += playerBuf.moveSpeed.GetValue(StageManager.moveSpeed) * frameTime;

            if (runningLength >= StageManager.Instance.monsterSpawnLength)
            {
                runningLength -= StageManager.Instance.monsterSpawnLength;
                StageManager.Instance.Spawn();
            }
        }


        entityStateMachine.StateUpdate(frameTime);
        SkillManager.Instance.Update(frameTime);
    }
    protected void Start()
    {
        entityStateMachine = new StateMachine();
        entityStateMachine.AddState(StateEnum.Idle, new BaseState(IdleStart));
        entityStateMachine.AddState(StateEnum.Run, new BaseState(RunStart, null, RunEnd));
        entityStateMachine.AddState(StateEnum.Attack, new BaseState(AttackStart, AttackUpdate));

        SkillManager.Instance.SelectSkill(1);
        //SkillManager.Instance.SelectSkill(2);
        SkillManager.Instance.SelectSkill(3);
    }

    #region 전투 관련

    public void HealHP(float _HealRatio)
    {
        float healAmount = entityHP * _HealRatio;
        entityCurrentHP += healAmount;
        if (entityCurrentHP > entityHP)
        {
            entityCurrentHP = entityHP;
        }

        hpBar.SetFill(entityCurrentHP / entityHP);
    }

    public override float GetDamage()
    {
        return playerBuf.attack.GetValue(entityAttack);
    }

    #endregion


    #region StateMachine

    void IdleStart()
    {
        animator.Play(AnimHash.IdleHash);
    }

    void RunStart()
    {
        animator.Play(AnimHash.RunHash);
        isRunning = true;
    }

    void RunEnd()
    {
        isRunning = false;
    }

    void AttackStart()
    {
        animator.Play(AnimHash.AttackHash);
    }

    void AttackUpdate(float _DeltaTime)
    {
        if (true == AnimHelper.IsAnimationEnd(animator))
        {
            if (null == selectedMonster)
            {
                SetState(StateEnum.Run);
            }
            else
            {
                animator.Play(AnimHash.AttackHash, 0, 0f);
            }
        }
    }

    void SkillStart()
    {
        animator.Play(AnimHash.AttackHash);
    }

    void SkillUpdate(float _DeltaTime)
    {
        if (true == AnimHelper.IsAnimationEnd(animator))
        {
            animator.Play(AnimHash.AttackHash);
        }
    }

    void SkillEnd()
    {

    }

    #endregion

    #region 애니메이션 콜백
    void SkillSpawn()
    {
        SkillBase spawnedSkill = SkillManager.Instance.ExcuteSkill();
        if (null == spawnedSkill)
        {
            spawnedSkill = SkillManager.Instance.SpawnNormalSkill();
        }
        spawnedSkill.skillOnwer = this;

        if (skillEnum.Attack == spawnedSkill.skillData.skillType)
        {
            spawnedSkill.transform.position = selectedMonster.transform.position;
        }
        else
        {
            spawnedSkill.transform.position = transform.position;
        }

    }
    #endregion

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        Entitiy monster = collision.GetComponent<Entitiy>();
        if (monster != null)
        {
            selectedMonster = monster;
            entityStateMachine.SetState(StateEnum.Attack);
        }
    }

    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (null != selectedMonster && collision.gameObject == selectedMonster.gameObject)
        {
            selectedMonster = null;
        }
    }

}
