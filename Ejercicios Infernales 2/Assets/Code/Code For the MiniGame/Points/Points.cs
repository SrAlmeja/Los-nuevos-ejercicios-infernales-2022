using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Points : MonoBehaviour
{
    PointsSpawner pointsSpawner;


    // Start is called before the first frame update
    private void Start()
    {
        pointsSpawner = GetComponent<PointsSpawner>();
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            // pointsSpawner.MakeDesSpawnWork();
        }
    }

}
