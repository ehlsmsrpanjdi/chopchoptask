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
    PlayerInventory Inventory = new PlayerInventory();
    PlayerStat playerStat = new PlayerStat();

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
    }

    #region 전투 관련

    public void HealHP(float _HealRatio)
    {
        float currentMaxHP = GetHP();
        float healAmount = currentMaxHP * _HealRatio;
        entityCurrentHP += currentMaxHP;
        if (entityCurrentHP > currentMaxHP)
        {
            entityCurrentHP = currentMaxHP;
        }

        hpBar.SetFill(entityCurrentHP / currentMaxHP);
    }

    public override float GetDamage()
    {
        return playerBuf.attack.GetValue(entityAttack + playerStat.GetStr());
    }

    public float GetHP()
    {
        return entityHP + playerStat.GetHp();
    }

    public int GetCritical()
    {
        return entityCriticalChange + playerStat.GetCChance();
    }

    public float GetCriticalDamage()
    {
        return GetDamage() * (entityCriticalDamage + playerStat.GetCDamage() + 100) / 100;
    }

    #endregion


    #region 인벤 및 강화

    public void GainGold(int _GoldAmount)
    {
        Inventory.GainGold(_GoldAmount);
        UIManager.Instance.GetUI<GoldUI>().TextUpdate();
    }

    public bool UseGold(int _UseAmount)
    {
        bool returnValue = Inventory.UseGold(_UseAmount);
        UIManager.Instance.GetUI<GoldUI>().TextUpdate();
        return returnValue;
    }

    public int GetGold()
    {
        return Inventory.GetGold();
    }

    public bool StrUpgrade()
    {
        return playerStat.StrLevelUp();
    }

    public bool HpUpgrade()
    {
        if (true == playerStat.HPLevelUp())
        {
            HealHP(playerStat.GetHp());
            hpBar.SetFill(entityCurrentHP / GetHP());
            return true;
        }
        return false;
    }

    public bool CDamageUpgrade()
    {
        return playerStat.CDamageLevelUp();
    }

    public bool CChanceUpgrade()
    {
        return playerStat.CChanceLevelUP();
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
