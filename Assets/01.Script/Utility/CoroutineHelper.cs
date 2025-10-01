using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public static class CoroutineHelper
{
    private static readonly Dictionary<float, WaitForSeconds> WaitForSecondsCache = new Dictionary<float, WaitForSeconds>(new FloatComparer());

    public static WaitForSeconds WaitTime(float _second)
    {
        if (true == WaitForSecondsCache.TryGetValue(_second, out WaitForSeconds waitForSeconds))
        {
            return waitForSeconds;
        }
        else
        {
            WaitForSecondsCache.Add(_second, new WaitForSeconds(_second));
        }
        return WaitForSecondsCache[_second];
    }
}