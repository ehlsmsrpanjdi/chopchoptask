public class ModifierStat
{
    public ModifierManager<float> attack { get; private set; } = new ModifierManager<float>();
    public ModifierManager<float> moveSpeed { get; private set; } = new ModifierManager<float>();

    public void Update(float _DeltaTime)
    {
        attack.Update(_DeltaTime);
        moveSpeed.Update(_DeltaTime);
    }
}
