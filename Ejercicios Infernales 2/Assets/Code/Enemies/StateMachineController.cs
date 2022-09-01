using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;

public class StateMachineController : MonoBehaviour
{
    // States
    public MonoBehaviour NormalState;
    public MonoBehaviour PersecutionState;
    public MonoBehaviour InitialState;
    private MonoBehaviour MyState;
    void Start()
    {
        ActivationState(InitialState);
    }

    public void ActivationState(MonoBehaviour newstate)
    {
        if (MyState != null) { MyState.enabled = false;}
        MyState = newstate;
        MyState.enabled = true;
    }
}
