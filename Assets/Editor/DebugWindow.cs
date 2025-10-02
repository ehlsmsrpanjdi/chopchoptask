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

        if (GUILayout.Button("gainGold"))
        {
            Player.Instance.GainGold(100000);
        }

        if (GUILayout.Button("playerAttackSpeed"))
        {
            Player.Instance.animator.SetFloat("AttackSpeed", 10f);
        }

    }
}
