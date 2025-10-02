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

        DebugGameStart();
    }

    IEnumerator NextStage()
    {
        yield return SceneManager.LoadSceneAsync("StageScene");
        StageManager.Instance.NextStage();
        Player.Instance.NextStage();
        yield return CoroutineHelper.WaitTime(1.0f);
        StageManager.Instance.StageStart();
    }

    IEnumerator PrevStage()
    {
        if (false == isGameInit)
        {
            LogHelper.Log("로딩 아직 안됨");
            yield break;
        }
        yield return SceneManager.LoadSceneAsync("StageScene");
        StageManager.Instance.StageFail();
        Player.Instance.NextStage();
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
        if (StageManager.Instance.completeStage >= StageManager.Instance.currentStage)
        {
            StartCoroutine(NextStage());
        }
        else
        {
            return;
        }
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
