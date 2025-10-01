using UnityEngine;

public class UIBase : MonoBehaviour
{


    public virtual void OnUI()
    {
        gameObject.SetActive(true);
    }

    public virtual void OffUI()
    {
        gameObject.SetActive(false);
    }
}
