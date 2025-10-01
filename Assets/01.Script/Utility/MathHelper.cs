using UnityEngine;

public static class MathHelper
{
    public static bool GetPercentageByBool(int n)
    {
        if (100 <= n)
        {
            return true;
        }
        if (0 >= n)
        {
            return false;
        }

        int rand = Random.Range(0, 100);
        return rand < n;
    }
}
