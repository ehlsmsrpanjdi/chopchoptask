using UnityEngine;

public class EntityHPBar : MonoBehaviour
{
    public GameObject hpFill;

    private void Reset()
    {
        hpFill = transform.GetChild(0).gameObject;
    }
    public void SetFill(float Ratio)
    {
        hpFill.transform.localScale = new Vector3(Ratio, 1f, 0f);
        hpFill.transform.localPosition = new Vector3(-(1 - Ratio) / 2, 0f, 0f);
    }
}
