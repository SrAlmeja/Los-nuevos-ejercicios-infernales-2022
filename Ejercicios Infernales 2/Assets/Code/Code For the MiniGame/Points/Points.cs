using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField] IntVariables points;
    public TextMeshProUGUI pointsText;


    // Start is called before the first frame update
    private void Start()
    {
        points.Value = 0;
    }

    private void Update()
    {
        points.Value = Math.Clamp(points.Value, 00, 40);
        pointsText.text = points.Value.ToString();
    }

    
    
    private void OnTriggerEnter(/*GameObject primitive, GameObject go, */Collider other)
    {
        Debug.Log("Funciona el trigger");
        if (other.gameObject.CompareTag("Points"))
        {
            Debug.Log("Me tocan");
            points.Value ++;
        }
        // if (other.gameObject.CompareTag("Points"))
        // //     {
        // //         ObjectPooler.RecicleObject(primitive, go);
        // //     }
    }

}
