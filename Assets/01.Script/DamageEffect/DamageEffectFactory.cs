using UnityEngine;

public static class DamageEffectFactory
{
    public static void SpawnDamageEffect(float _Damage, Entitiy _Target)
    {
        GameObject obj = ResourceManager.Instance.GetOnLoadedResource("DamageEffect");
        GameObject onSpawnedObj = MonoBehaviour.Instantiate(obj);
        DamageEffect effect = onSpawnedObj.GetComponent<DamageEffect>();
        int damageToint = (int)_Damage;
        effect.Init(damageToint.ToString());
        onSpawnedObj.transform.position = _Target.transform.position + Vector3.up * 3;
    }
}
