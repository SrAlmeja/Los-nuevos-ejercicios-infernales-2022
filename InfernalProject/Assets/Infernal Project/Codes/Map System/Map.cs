using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Timeline;

public class Map : MonoBehaviour
{
    [Header ("Board")]
    private GameObject[,] _map;
    private int _height, _width;
    private float _scale;
    private Vector2 _rotX, _rotY;
    private float _offset;
    private bool _isIso;
    private GameObject _prefab;
    private Block _start, _goal;
    
    private float sizeX, sizeY;
    public int  Width
    {
        get { return _width; }
        set { _width = value; }
    }
    public int  Height
    {
        get { return _height; }
        set { _height = value; }
    }
    public float Scale
    {
        get { return _scale; }
        set { _scale = value; }
    }

    public bool IsIso
    {
        get { return _isIso; }
        set { _isIso = value; }
    }
    
    public GameObject Prefab
    {
        get { return _prefab; }
        set { _prefab = value; }
    }
    
    public float Offset
    {
        get { return _offset; }
        set { _offset = value; }
    }
    
    private MapManager _mapManager;
    

    public void addComponents()
    {
        _mapManager = GetComponent<MapManager>();
    }
    
    public void CreateMap(GameObject  prefab, bool iso=false, Sprite sprite= null)
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
                floor.transform.localScale *= _scale;
                sizeX = floor.transform.localScale.x;
                sizeY = floor.transform.localScale.y;
                floor.transform.position = new Vector3( sizeX +_offset * (0.5f+i) , sizeX +_offset * (0.5f+j),0);

                _map[i, j] = floor;
            }           
        }

        //transform.position = new Vector3(sizeX * (_width / 2), sizeY * (_height / 2));
    }



    public void CreateIsoMap(GameObject gameObject, SpriteRenderer, )
    {
        
    }

    public void centerMap()
    {
        
    }
}
