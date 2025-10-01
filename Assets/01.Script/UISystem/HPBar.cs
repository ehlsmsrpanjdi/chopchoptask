using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Image hpFill;

    Entitiy target;

    private void Reset()
    {
        hpFill = transform.GetChild(0).GetComponent<Image>();
    }

    public void Init(Entitiy _Entity)
    {
        target = _Entity;
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        float ratio = Mathf.Clamp01(target.GetHPRatio());
        hpFill.fillAmount = ratio;

        transform.position = Camera.main.WorldToScreenPoint(target.transform.position + Vector3.up * 2f);
    }
}
