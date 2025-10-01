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
        if (GUILayout.Button("StartGame"))
        {
            GameManager.Instance.DebugGameStart();
        }

        if (GUILayout.Button("NextStage"))
        {
            GameManager.Instance.DebugNextStage();
        }

        if (GUILayout.Button("BossSpawn"))
        {
            StageManager.Instance.SpawnBoss();
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
