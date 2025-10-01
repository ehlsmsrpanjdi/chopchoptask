using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    public Canvas mainCanvas;

    Dictionary<Type, UIBase> uiDictionary = new Dictionary<Type, UIBase>();
    Dictionary<Type, string> uiResourceDictoinary = new Dictionary<Type, string>();

    private void Awake()
    {
        if (null != instance)
        {
            Destroy(transform.gameObject);
        }
        else
        {
            instance = this;
            Init();
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    void Init()
    {
        uiResourceDictoinary.Add(typeof(BossUI), "UI/BossUI");
        uiResourceDictoinary.Add(typeof(GoldUI), "UI/GoldUI");
        uiResourceDictoinary.Add(typeof(PlayerStatUI), "UI/PlayerStatUI");
    }


    public T AddUI<T>() where T : UIBase
    {
        Type key = typeof(T);
        if (false == uiDictionary.ContainsKey(typeof(T)))
        {
            GameObject uiObj = ResourceManager.Instance.GetOnLoadedResource(uiResourceDictoinary[key]);
            GameObject spawnedUI = MonoBehaviour.Instantiate(uiObj, transform);
            T uiType = spawnedUI.GetComponent<T>();
            uiDictionary.Add(key, uiType);
            return uiType;
        }
        else
        {
            return uiDictionary[key] as T;
        }

    }

    public T GetUI<T>() where T : UIBase
    {
        Type key = typeof(T);
        if (uiDictionary.ContainsKey(key))
        {
            return uiDictionary[key] as T;
        }
        else
        {
            return AddUI<T>();
        }
    }
}
