using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private Vector2 size;
    private GameObject prefab;
    private bool isIso;
    private float Offset;
    private Color selectedBlock;
    private Color startColor;
    private Color endColor;
    private Map _map;

    private void Awake()
    {
        _map = GetComponent<Map>();
        _map.CreateMap();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
