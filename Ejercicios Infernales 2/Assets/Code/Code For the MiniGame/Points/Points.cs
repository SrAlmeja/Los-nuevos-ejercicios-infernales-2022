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
    PointsSpawner pointsSpawner;


    // Start is called before the first frame update
    private void Start()
    {
        points.Value = 0;
        pointsSpawner = GetComponent<PointsSpawner>();
    }

    private void Update()
    {
        points.Value = Math.Clamp(points.Value, 00, 40);
        pointsText.text = points.Value.ToString();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        int actualPoints = points.Value;
        int countedPoints = 0;
        
        if (other.gameObject.CompareTag("Points"))
        {
            points.Value ++;
            // pointsSpawner.MakeDesSpawnWork();
        }
    }

}
