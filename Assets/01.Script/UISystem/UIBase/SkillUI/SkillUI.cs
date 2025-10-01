using System.Collections.Generic;
using System.Linq;

public class SkillUI : UIBase
{
    public List<SkillSlotUI> skillSlots = new List<SkillSlotUI>();

    private void Reset()
    {
        skillSlots = GetComponentsInChildren<SkillSlotUI>().ToList<SkillSlotUI>();


    }

    private void Awake()
    {
        for (int i = 0; i < skillSlots.Count; ++i)
        {
            skillSlots[i].SlotIndex = i;
        }
    }

    public void SkillUse(int _SkillIndex)
    {
        skillSlots[_SkillIndex].SkillExcute();
    }

    //public void UnSelectSkill(int _SlotIndex)
    //{
    //    skillSlots[_SlotIndex].Init();
    //}

    public override void OnUI()
    {
        base.OnUI();
        foreach (SkillSlotUI slot in skillSlots)
        {
            slot.Init();
        }
    }

    public void SkillChangeMode()
    {
        foreach (SkillSlotUI slot in skillSlots)
        {
            slot.SkillChangeMode();
        }
    }

    public void EndSkillChangeMode()
    {
        foreach (SkillSlotUI slot in skillSlots)
        {
            slot.EndSkillChangeMode();
        }
    }
}
