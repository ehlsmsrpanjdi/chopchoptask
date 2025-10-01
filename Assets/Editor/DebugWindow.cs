using UnityEditor;
using UnityEngine;


public class DebugWindow : EditorWindow
{
    [MenuItem("Window/DebugWindow")]
    public static void ShowWindow()
    {
        GetWindow<DebugWindow>("DebugWindow");
    }

    float moveValue;

    private void OnGUI()
    {
        if (GUILayout.Button("ResourceLoad"))
        {
            ResourceManager.Instance.ResourceInit();
            StageMonsterInfo.Instance.Init();
            SkillManager.Instance.TestInit();
        }

        if (GUILayout.Button("stageStart"))
        {
            StageManager.Instance.StageStart();
        }

        if (GUILayout.Button("Idle"))
        {
            Player.Instance.SetState(StateEnum.Idle);
        }

        if (GUILayout.Button("Run"))
        {
            Player.Instance.SetState(StateEnum.Run);
        }


    }
}
