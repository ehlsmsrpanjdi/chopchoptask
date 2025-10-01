using UnityEngine;

public static class AnimHash
{
    public const string IdleAnimationName = "Idle";
    public const string RunAnimationName = "Run";
    public const string AttackAnimationName = "Attack";

    public static readonly int IdleHash = Animator.StringToHash(IdleAnimationName);
    public static readonly int RunHash = Animator.StringToHash(RunAnimationName);
    public static readonly int AttackHash = Animator.StringToHash(AttackAnimationName);
}

public static class AnimHelper
{
    public static bool IsAnimationEnd(Animator animator)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}