using UnityEngine;

public static class DamageEffectFactory
{
    public static GameObject SpawnDamageEffect(float _Damage, Entitiy _Target)
    {
        GameObject obj = ResourceManager.Instance.GetOnLoadedResource("DamageEffect");
        GameObject onSpawnedObj = MonoBehaviour.Instantiate(obj);
        DamageEffect effect = onSpawnedObj.GetComponent<DamageEffect>();
        int damageToint = (int)_Damage;
        effect.Init(damageToint.ToString());
        onSpawnedObj.transform.position = _Target.transform.position + Vector3.up * 3;
        return onSpawnedObj;
    }

    public static GameObject SpawnDamageCriticalEffect(float _Damage, Entitiy _Target)
    {
        GameObject obj = ResourceManager.Instance.GetOnLoadedResource("DamageEffect");
        GameObject onSpawnedObj = MonoBehaviour.Instantiate(obj);
        DamageEffect effect = onSpawnedObj.GetComponent<DamageEffect>();
        int damageToint = (int)_Damage;
        effect.RedInit(damageToint.ToString());
        onSpawnedObj.transform.position = _Target.transform.position + Vector3.up * 3;
        return onSpawnedObj;
    }
}
