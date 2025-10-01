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

    Dictionary<string, Sprite> spriteResourceDictionary = new Dictionary<string, Sprite>();

    public IEnumerator ResourceInit()
    {
        yield return LoadResource("Skill/Skill_0");
        yield return LoadResource("Skill/Skill_1");
        yield return LoadResource("Skill/Skill_2");
        yield return LoadResource("Skill/Skill_3");
        yield return LoadResource("DamageEffect");
        yield return LoadResource("Monster_1");

        yield return LoadResource("UI/BossUI");
        yield return LoadResource("UI/GoldUI");
        yield return LoadResource("UI/PlayerStatUI");
    }

    public Sprite GetOnLoadedSprite(string _resourcePath)
    {
        return spriteResourceDictionary[_resourcePath];
    }

    public GameObject GetOnLoadedResource(string _ResourcePath)
    {
        return resourceDictionary[_ResourcePath];
    }

    public IEnumerator LoadSprite(string _ResourcePath)
    {
        ResourceRequest request = Resources.LoadAsync<Sprite>(_ResourcePath);
        yield return request;
        Sprite loadedObj = request.asset as Sprite;
        spriteResourceDictionary.Add(_ResourcePath, loadedObj);
        yield break;
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
