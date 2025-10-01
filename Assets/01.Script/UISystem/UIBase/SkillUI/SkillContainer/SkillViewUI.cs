using UnityEngine;
using UnityEngine.UI;

public class SkillViewUI : MonoBehaviour
{
    public Image skillIcon;
    public Button skillIconButton;
    public int selectedSkillID;
    private void Reset()
    {
        skillIcon = this.TryFindChild("SkillIcon").GetComponent<Image>();
        skillIconButton = transform.GetComponent<Button>();
    }

    public void Init(int _SkillId)
    {
        skillIcon.sprite = ResourceManager.Instance.GetOnLoadedSprite("Sprite/Skill_" + _SkillId.ToString());
        selectedSkillID = _SkillId;
    }

    private void Start()
    {
        skillIconButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        SkillContainerUI Owner = UIManager.Instance.GetUI<SkillContainerUI>();
        Owner.SetDiscription("asdf");
    }
}
