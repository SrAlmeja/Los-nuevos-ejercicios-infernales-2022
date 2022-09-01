using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    [SerializeField] public BoolVariable isOnArea;
    private StateMachineController stateMachineController;

    private void Awake()
    {
        stateMachineController = GetComponent<StateMachineController>();
    }

    private void Start()
    {
        isOnArea.Value = false;
        return;
    }

    private void Update()
    {
        if (isOnArea)
        {
            stateMachineController.ActivationState(stateMachineController.PersecutionState);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnArea.Value = true;
            Debug.Log("Toque al jugador");
            stateMachineController.ActivationState(stateMachineController.PersecutionState);
            return;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnArea.Value = false;
            Debug.Log("Deje de tocarlo");
            stateMachineController.ActivationState(stateMachineController.NormalState);
            return;
        }
    }
}
