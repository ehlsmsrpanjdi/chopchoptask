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

    public bool Init(int _SkillId)
    {
        if (null == SkillDataManager.Instance.GetSkillData(_SkillId))
        {
            return false;
        }

        skillIcon.sprite = ResourceManager.Instance.GetOnLoadedSprite("Sprite/Skill_" + _SkillId.ToString());
        selectedSkillID = _SkillId;
        return true;
    }

    private void Start()
    {
        skillIconButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        SkillContainerUI Owner = UIManager.Instance.GetUI<SkillContainerUI>();
        SkillData data = SkillDataManager.Instance.GetSkillData(selectedSkillID);
        Owner.SetDiscription(EffectDiscriptionFactory.Instance.GetEffectDiscription(data));
        Owner.selectedSkillID = selectedSkillID;
    }
}
