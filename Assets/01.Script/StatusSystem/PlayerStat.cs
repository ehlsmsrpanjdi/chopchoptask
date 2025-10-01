public class PlayerStat
{
    int STRLv = 1;
    int HPLv = 1;
    int CDamageLv = 1;
    int CChanceLv = 1;

    int priceValue = 100;

    public int GetStr()
    {
        return STRLv * 5;
    }

    public int GetHp()
    {
        return HPLv * 5;
    }

    public int GetCDamage()
    {
        return CDamageLv * 5;
    }

    public int GetCChance()
    {
        return CChanceLv;
    }

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

    public bool CDamageLevelUp()
    {
        if (true == Player.Instance.UseGold(GetPrice(CDamageLv)))
        {
            ++CDamageLv;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CChanceLevelUP()
    {
        if (true == Player.Instance.UseGold(GetPrice(CChanceLv)))
        {
            ++CChanceLv;
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
