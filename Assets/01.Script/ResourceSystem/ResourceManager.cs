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
        yield return LoadResource("Skill/Skill_4");
        yield return LoadResource("Skill/Skill_5");
        yield return LoadResource("Skill/Skill_6");
        yield return LoadResource("Skill/Skill_7");
        yield return LoadResource("Skill/Skill_8");
        yield return LoadResource("Skill/Skill_9");
        yield return LoadResource("DamageEffect");

        yield return LoadResource("Monster_1");
        yield return LoadResource("Monster_2");
        yield return LoadResource("Monster_3");

        yield return LoadResource("UI/BossUI");
        yield return LoadResource("UI/GoldUI");
        yield return LoadResource("UI/PlayerStatUI");
        yield return LoadResource("UI/SkillUI");
        yield return LoadResource("UI/SelectorUI");
        yield return LoadResource("UI/SkillContainerUI");


        yield return LoadSprite("Sprite/Skill_-1");
        yield return LoadSprite("Sprite/Skill_1");
        yield return LoadSprite("Sprite/Skill_2");
        yield return LoadSprite("Sprite/Skill_3");
        yield return LoadSprite("Sprite/Skill_4");
        yield return LoadSprite("Sprite/Skill_5");
        yield return LoadSprite("Sprite/Skill_6");
        yield return LoadSprite("Sprite/Skill_7");
        yield return LoadSprite("Sprite/Skill_8");
        yield return LoadSprite("Sprite/Skill_9");
        yield return LoadSprite("Sprite/Change");
        //yield return LoadSprite("Sprite/Skil_4");
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
