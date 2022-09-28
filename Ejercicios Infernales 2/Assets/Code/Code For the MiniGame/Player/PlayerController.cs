using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] IntVariables points;
    public TextMeshProUGUI pointsText;
    PointsSpawner _pointsSpawner;


    private void Awake()
    {
        _pointsSpawner = GetComponent<PointsSpawner>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        points.Value = 0;
    }

    private void Update()
    {
        points.Value = Mathf.Clamp(points.Value, 00, 40);
        pointsText.text = points.Value.ToString();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Points"))
        {
            points.Value ++;
            Debug.Log("Trigger Funciona");
        }
    }

}
