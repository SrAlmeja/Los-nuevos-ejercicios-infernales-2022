using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private GameObject[,] _map;
    [SerializeField]private int _height, _width;
    private Vector2 _rotX, _rotY;
    [SerializeField] private float _offset;
    private bool _isIso;
    public GameObject prefab;

    private MapManager _mapManager;
    

    public void addComponents()
    {
        _mapManager = GetComponent<MapManager>();
    }
    
    public void CreateMap()
    {
        _map = new GameObject[_height, _width];
        // if (_isIso = true)
        // {
        //     CreateIsoMap();
        // }
        // else
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                GameObject floor = Instantiate(prefab);
                floor.name = $"{i}-{j}";

                floor.transform.parent = transform;
                floor.transform.position = new Vector3( i+(-_height / 2) , j+(-_width / 2),0);
            }           
        }
    }

    

    public void CreateIsoMap()
    {
        
    }

    public void centerMap()
    {
        
    }
}
