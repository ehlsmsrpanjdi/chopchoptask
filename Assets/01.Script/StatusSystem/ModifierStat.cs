public class ModifierStat
{
    public ModifierManager<float> attack { get; private set; } = new ModifierManager<float>();
    public ModifierManager<float> moveSpeed { get; private set; } = new ModifierManager<float>();

    public ModifierManager<float> attackSpeed { get; private set; } = new ModifierManager<float>();

    public void Update(float _DeltaTime)
    {
        attack.Update(_DeltaTime);
        moveSpeed.Update(_DeltaTime);
        attackSpeed.Update(_DeltaTime);
    }

    public void Reset()
    {
        attack.Reset();
        moveSpeed.Reset();
        attackSpeed.Reset();
    }
}
