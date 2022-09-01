using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    [SerializeField] public BoolVariable isOnArea;

    private void Start()
    {
        isOnArea.Value = false;
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOnArea.Value = true;
            Debug.Log("Toque al jugador");
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOnArea.Value = false;
            Debug.Log("Deje de tocarlo");
            return;
        }
    }
}
