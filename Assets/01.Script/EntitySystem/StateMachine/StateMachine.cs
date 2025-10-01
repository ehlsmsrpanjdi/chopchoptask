using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    Dictionary<StateEnum, BaseState> stateDictionary = new Dictionary<StateEnum, BaseState>();

    StateEnum currentState = StateEnum.None;

    public void SetState(StateEnum _State)
    {
        if (StateEnum.None != currentState && currentState != _State)
        {
            if (false == stateDictionary.ContainsKey(_State))
            {
                LogHelper.Log("Null State Call");
            }
            stateDictionary[currentState].End();
        }

        currentState = _State;
        stateDictionary[_State].Start();
    }

    public void StateUpdate(float _DeltaTime)
    {
        if (StateEnum.None != currentState)
        {
            stateDictionary[currentState].Update(_DeltaTime);
        }
    }

    public void AddState(StateEnum _Enum, BaseState _State)
    {
        if (true == stateDictionary.ContainsKey(_Enum))
        {
            LogHelper.Log("있는거 또 넣음");
        }
        stateDictionary.Add(_Enum, _State);
    }
}
