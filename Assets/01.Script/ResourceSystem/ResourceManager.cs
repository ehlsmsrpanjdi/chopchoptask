using System.Collections;
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

    public IEnumerator ResourceInit()
    {
        yield return LoadResource("Skill/Skill_0");
        yield return LoadResource("Skill/Skill_1");
        yield return LoadResource("Skill/Skill_2");
        yield return LoadResource("Skill/Skill_3");
        yield return LoadResource("DamageEffect");
        yield return LoadResource("Monster_1");
    }

    public GameObject GetOnLoadedResource(string _ResourcePath)
    {
        return resourceDictionary[_ResourcePath];
    }

    public IEnumerator LoadResource(string _ResourcePath)
    {
        ResourceRequest request = Resources.LoadAsync<GameObject>(_ResourcePath);
        yield return request;
        GameObject loadedObj = request.asset as GameObject;
        resourceDictionary.Add(_ResourcePath, loadedObj);
        yield break;
    }
}
