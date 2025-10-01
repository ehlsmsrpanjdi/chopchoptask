using System.Collections.Generic;
using System.Linq;

public class SkillUI : UIBase
{
    public List<SkillSlotUI> skillSlots = new List<SkillSlotUI>();

    private void Reset()
    {
        skillSlots = GetComponentsInChildren<SkillSlotUI>().ToList<SkillSlotUI>();
    }

    public void SkillUse(int _SkillIndex)
    {

    }
}
