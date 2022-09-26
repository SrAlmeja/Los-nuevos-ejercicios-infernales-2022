using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public IntVariables points;
    [SerializeField] TextMeshPro pointsText;


    // Start is called before the first frame update
    private void Awake()
    {
        points.Value = 0;
    }

    private void Update()
    {
        
        pointsText.text = points.Value.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            points.Value++;
        }

    }
}
