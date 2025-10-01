using TMPro;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    public TextMeshPro damageText;

    float moveTime = 1f;

    float upSpeed = .5f;

    private void Reset()
    {
        damageText = GetComponent<TextMeshPro>();
    }


    public void Init(string _Str)
    {
        damageText.text = _Str;
        moveTime = 2f;
    }

    private void FixedUpdate()
    {
        if (moveTime > 0f)
        {
            transform.position = transform.position + new Vector3(0f, upSpeed * Time.deltaTime, 0f);
            moveTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
