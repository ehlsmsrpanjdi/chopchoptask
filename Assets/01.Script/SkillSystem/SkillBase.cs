using Unity.VisualScripting;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    public EffectBase skillEffect;
    public SkillData skillData;

    int excuteTime;

    public Entitiy skillOnwer;

    [SerializeField] Animator animator;

    [SerializeField] BoxCollider2D collision;

    private void Reset()
    {
        animator = GetComponent<Animator>();
        collision = GetComponent<BoxCollider2D>();
        if (null == collision)
        {
            collision = transform.AddComponent<BoxCollider2D>();
        }
    }

    public void Init(int _SkillID)
    {
        skillData = SkillDataManager.Instance.GetSkillData(_SkillID);
        skillEffect = EffectManager.Instance.GetEffect(skillData.effectID);
        excuteTime = skillData.hitCount;
    }

    public void Init(SkillData _SkillData)
    {
        skillData = _SkillData;
        skillEffect = EffectManager.Instance.GetEffect(skillData.effectID);
        excuteTime = skillData.hitCount;
    }
    private void Start()
    {
        if (null == skillData)
        {
            LogHelper.Log("??");
            return;
        }
        if (skillEnum.Attack != skillData.skillType)
        {
            Player.Instance.StartCoroutine(skillEffect.Excute(skillData, Player.Instance));
        }
    }

    private void Update()
    {
        if (true == AnimHelper.IsAnimationEnd(animator))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (null == skillData)
        {
            LogHelper.Log("??");
            return;
        }
        if (excuteTime <= 0 || skillEnum.Attack != skillData.skillType)
        {
            return;
        }
        Monster monster = collision.GetComponent<Monster>();

        if (null == monster)
        {
            return;
        }

        --excuteTime;
        Player.Instance.StartCoroutine(skillEffect.Excute(skillData, Player.Instance, monster));
    }
}
