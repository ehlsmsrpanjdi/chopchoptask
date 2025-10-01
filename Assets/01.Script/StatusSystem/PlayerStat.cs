public class PlayerStat
{
    public int STRLv;
    public int HPLv;

    public int priceValue = 100;

    public bool StrLevelUp()
    {
        if (true == Player.Instance.UseGold(GetPrice(STRLv)))
        {
            ++STRLv;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HPLevelUp()
    {
        if (true == Player.Instance.UseGold(GetPrice(HPLv)))
        {
            ++HPLv;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetPrice(int _Lv)
    {
        return _Lv * priceValue;
    }
}
