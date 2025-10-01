using System.Collections;

public abstract class EffectBase
{
    public abstract IEnumerator Excute(SkillData _skillData, Player _User, Entitiy _Target = null);
}


public class AttackEffect : EffectBase
{
    public override IEnumerator Excute(SkillData _skillData, Player _User, Entitiy _Target = null)
    {
        if (_Target == null) yield break;

        for (int i = 0; i < _skillData.hitInterval; i++)
        {
            if (null == _Target)
            {
                yield break;
            }
            float damage = _User.GetDamage() * _skillData.damageRatio / 100;
            _Target.TakeDamage(damage);

            yield return CoroutineHelper.WaitTime(0.1f);
        }
    }
}

public class HealEffect : EffectBase
{
    public override IEnumerator Excute(SkillData _skillData, Player _User, Entitiy _Target = null)
    {
        _User.HealHP(_skillData.damageRatio / 100);
        yield break;
    }
}

public class PassiveAttackEffect : EffectBase
{
    public override IEnumerator Excute(SkillData _skillData, Player _User, Entitiy _Target = null)
    {
        MultiModifier modifier = new MultiModifier(_skillData.damageRatio);  // 비율만큼 빨라지고
        modifier.bufTime = _skillData.hitCount;             // 카운트가 초
        _User.playerBuf.moveSpeed.AddModifier(modifier);
        yield break;
    }
}

public class PassiveMoveSpeedEffect : EffectBase
{
    public override IEnumerator Excute(SkillData _skillData, Player _User, Entitiy _Target = null)
    {
        MultiModifier modifier = new MultiModifier(_skillData.damageRatio);  // 비율만큼 빨라지고
        modifier.bufTime = _skillData.hitCount;             // 카운트가 초
        _User.playerBuf.moveSpeed.AddModifier(modifier);
        yield break;
    }
}

public class PassiveAttackSpeedEffect : EffectBase
{
    public override IEnumerator Excute(SkillData _skillData, Player _User, Entitiy _Target = null)
    {
        yield break;
    }
}