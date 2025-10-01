public abstract class EffectBase
{


    private EffectBase()
    {

    }

    public EffectBase(float effectSize, float damageRadio, int damageCount, skillEnum skillType)
    {
        this.effectSize = effectSize;
        this.damageRatio = damageRadio;
        this.damageCount = damageCount;
        this.skillType = skillType;
    }

    public skillEnum skillType { get; protected set; }

    public float effectSize { get; protected set; }

    public float damageRatio { get; protected set; }

    public int damageCount { get; protected set; }
    public abstract void Excute(Entitiy _User, Entitiy _Target = null);
}


public class AttackEffect : EffectBase
{
    public AttackEffect(float effectSize, float damageRadio, int damageCount, skillEnum skillType) : base(effectSize, damageRadio, damageCount, skillType)
    {
    }

    public override void Excute(Entitiy _User, Entitiy _Target = null)
    {
        float Damage = _User.GetDamage();
        _Target.TakeDamage(Damage * damageRatio);
    }

}

public class HealEffect : EffectBase
{
    public HealEffect(float effectSize, float damageRadio, int damageCount, skillEnum skillType) : base(effectSize, damageRadio, damageCount, skillType)
    {
    }

    public override void Excute(Entitiy _User, Entitiy _Target = null)
    {
        throw new System.NotImplementedException();
    }
}

public class PassiveEffect : EffectBase
{
    public PassiveEffect(float effectSize, float damageRadio, int damageCount, skillEnum skillType) : base(effectSize, damageRadio, damageCount, skillType)
    {

    }
    public override void Excute(Entitiy _User, Entitiy _Target = null)
    {
        throw new System.NotImplementedException();
    }
}