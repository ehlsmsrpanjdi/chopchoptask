using System;

public class BaseState
{
    Action onStartAction;
    Action<float> onUpdateAction;
    Action onFinishAction;

    private BaseState()
    {

    }

    public BaseState(Action onStartAction, Action<float> onUpdateAction = null, Action onFinishAction = null)
    {
        this.onStartAction = onStartAction;
        this.onUpdateAction = onUpdateAction;
        this.onFinishAction = onFinishAction;
    }

    public virtual void Start()
    {
        if (null != onStartAction)
        {
            onStartAction();
        }
    }
    public virtual void Update(float _DeltaTime)
    {
        if (null != onUpdateAction)
        {
            onUpdateAction(_DeltaTime);
        }
    }
    public virtual void End()
    {
        if (null != onFinishAction)
        {
            onFinishAction();
        }
    }
}
