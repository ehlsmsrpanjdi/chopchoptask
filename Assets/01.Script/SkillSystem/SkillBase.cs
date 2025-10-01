using UnityEngine;

public class SkillBase : MonoBehaviour
{
    public EffectBase skillEffect;

    public Entitiy skillOnwer;

    [SerializeField] Animator animator;

    [SerializeField] BoxCollider2D collision;

    private void Reset()
    {
        animator = GetComponent<Animator>();
        collision = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entitiy colEntity = collision.GetComponent<Entitiy>();

        if (null == colEntity)
        {
            LogHelper.LogWarrning("Entity가 아닌것과 충돌을 수행함");
            return;
        }

        if (skillEnum.Attack == skillEffect.skillType)
        {
            if (skillOnwer == colEntity)
            {
                return;
            }
            else
            {
                skillEffect.Excute(skillOnwer, colEntity);
                return;
            }
        }

        skillEffect.Excute(skillOnwer);
    }
}
