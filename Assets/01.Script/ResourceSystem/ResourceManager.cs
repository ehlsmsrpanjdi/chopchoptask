using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    static ResourceManager instance;

    public static ResourceManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new ResourceManager();
            }
            return instance;
        }
    }

    Dictionary<string, GameObject> resourceDictionary = new Dictionary<string, GameObject>();

    public void ResourceInit()
    {
        LoadResource("SkillEffect");
        LoadResource("DamageEffect");
        LoadResource("Monster_1");
    }

    public GameObject GetOnLoadedResource(string _ResourcePath)
    {
        return resourceDictionary[_ResourcePath];
    }

    public GameObject LoadResource(string _ResourcePath)
    {
        GameObject obj = Resources.Load<GameObject>(_ResourcePath);
        resourceDictionary.Add(_ResourcePath, obj);
        return obj;
    }
}
