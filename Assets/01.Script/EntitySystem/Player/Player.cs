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

        if(true == isRunning)
        {
            runningLength += StageManager.moveSpeed * frameTime;

            if (runningLength >= StageManager.Instance.monsterSpawnLength)
            {
                runningLength -= StageManager.Instance.monsterSpawnLength;
                StageManager.Instance.SpawnMonster();
            }
        }


        entityStateMachine.StateUpdate(frameTime);
    }
    protected void Start()
    {
        entityStateMachine = new StateMachine();
        entityStateMachine.AddState(StateEnum.Idle, new BaseState(IdleStart));
        entityStateMachine.AddState(StateEnum.Run, new BaseState(RunStart, null, RunEnd));
        entityStateMachine.AddState(StateEnum.Attack, new BaseState(AttackStart, null));
    }

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
        if (collision.gameObject == selectedMonster.gameObject)
        {
            entityStateMachine.SetState(StateEnum.Run);
        }
    }

    void SkillSpawn()
    {
        SkillBase spawnedSkill = SkillManager.Instance.SpawnSkill();
        spawnedSkill.transform.position = selectedMonster.transform.position;
        spawnedSkill.skillOnwer = this;
    }
}
