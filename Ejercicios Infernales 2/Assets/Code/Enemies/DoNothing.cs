using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNothing : MonoBehaviour
{
    [SerializeField] public BoolVariable isOnArea;
    private StateMachineController stateMachineController;
    private void Awake()
    {
        stateMachineController = GetComponent<StateMachineController>();
        isOnArea.Value = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerexit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnArea.Value = false;
            stateMachineController.ActivationState(stateMachineController.NormalState);
        }
    }
}
