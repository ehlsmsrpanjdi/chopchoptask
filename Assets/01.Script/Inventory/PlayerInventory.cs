public class PlayerInventory
{
    int gold;

    public void GainGold(int _GoldAmount)
    {
        gold += _GoldAmount;
    }

    public int GetGold()
    {
        return gold;
    }

    public bool UseGold(int _UseAmount)
    {
        if (true == gold < _UseAmount)
        {
            return false;
        }
        gold -= _UseAmount;
        return true;
    }
}
