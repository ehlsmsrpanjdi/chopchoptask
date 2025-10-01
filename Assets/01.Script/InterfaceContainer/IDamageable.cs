using UnityEngine;

public interface IDamageable
{
    public bool TakeDamage(float _Damage);
    public bool TakeCriticalDamage(float _Damage);
}
