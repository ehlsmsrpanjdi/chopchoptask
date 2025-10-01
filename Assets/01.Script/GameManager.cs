using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    bool isGameInit = false;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }


    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(GameStartCoroutine());
    }

    IEnumerator GameStartCoroutine()
    {
        yield return ResourceManager.Instance.ResourceInit();

        isGameInit = true;
    }

    public IEnumerator NextStage()
    {
        if (false == isGameInit)
        {
            LogHelper.Log("로딩 아직 안됨");
            yield break;
        }
        yield return SceneManager.LoadSceneAsync("StageScene");
        StageManager.Instance.NextStage();
        yield return CoroutineHelper.WaitTime(1.0f);
        StageManager.Instance.StageStart();
    }

    public IEnumerator PrevStage()
    {
        if (false == isGameInit)
        {
            LogHelper.Log("로딩 아직 안됨");
            yield break;
        }
        yield return SceneManager.LoadSceneAsync("StageScene");
        StageManager.Instance.StageFail();
        yield return CoroutineHelper.WaitTime(1.0f);
        StageManager.Instance.StageStart();
    }

    public IEnumerator GameStart()
    {
        if (false == isGameInit)
        {
            LogHelper.Log("로딩 아직 안됨");
            yield break;
        }
        UIManager.Instance.GetUI<GoldUI>();
        UIManager.Instance.GetUI<SelectorUI>();
        yield return SceneManager.LoadSceneAsync("StageScene");
        yield return CoroutineHelper.WaitTime(1.0f);
        StageManager.Instance.StageStart();
    }




    public void DebugNextStage()
    {
        StartCoroutine(NextStage());
    }

    public void DebugGameStart()
    {
        StartCoroutine(GameStart());
    }

    public void DebugStageFail()
    {
        StartCoroutine(PrevStage());
    }
}
