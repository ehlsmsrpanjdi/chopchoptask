using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entitiy : MonoBehaviour, IDamageable
{
    protected float entityAttack = 10;
    protected float entityHP = 100;
    protected float entityCurrentHP = 100;
    protected float entityHealAmount = 0;
    protected float entityCriticalDamage = 100;
    protected float entityCriticalChange = 1;

    public EntityHPBar hpBar;

    [field: SerializeField] public Animator animator { get; protected set; }
    [field: SerializeField] public Rigidbody2D rigid { get; protected set; }
    [field: SerializeField] public Collider2D collision { get; protected set; }

    protected virtual void Reset()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collider2D>();
        hpBar = transform.GetChild(0).GetComponent<EntityHPBar>();
    }


    protected StateMachine entityStateMachine;
    public void SetState(StateEnum _State)
    {
        if (null != entityStateMachine)
        {
            entityStateMachine.SetState(_State);
        }
    }

    public void StateUpdate(float _DelaTime)
    {
        entityStateMachine.StateUpdate(_DelaTime);
    }

    /// <summary>
    /// 사망시 true
    /// </summary>
    /// <param name="_Damage"></param>
    /// <returns></returns>
    public virtual bool TakeDamage(float _Damage)
    {
        entityCurrentHP -= _Damage;
        DamageEffectFactory.SpawnDamageEffect(_Damage, this);
        hpBar.SetFill(GetHPRatio());
        if (entityCurrentHP < 0)
        {
            Dead();
            return true;
        }
        return false;
    }

    public float GetHPRatio()
    {
        return entityCurrentHP / entityHP;
    }

    public virtual void Dead()
    {
        Destroy(gameObject);
    }

    public virtual float GetDamage()
    {
        return entityAttack;
    }


    public void SkillExcecute(IEnumerator _Coroutine)
    {
        StartCoroutine(_Coroutine);
    }
}
