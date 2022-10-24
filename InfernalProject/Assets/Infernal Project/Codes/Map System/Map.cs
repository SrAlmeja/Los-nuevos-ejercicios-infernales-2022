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
    private int _order;
    
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

    public Vector2Int size
    {
        get { return new Vector2Int(_width, _height); }
        set
        {
            _width = value.x;
            _height = value.y;
        }
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
    
    public void CreateMap(GameObject  prefab, bool iso=false, SpriteRenderer sprite= null)
    {
        _order = _width * _height;
        _map = new GameObject[_height, _width];
        
        for (int y=0; y<_height; y++)
        {
            for (int x=0; x<_width; x++)
            {
                GameObject floor = Instantiate(prefab);
                SpriteRenderer renderer = floor.GetComponent<SpriteRenderer>();
                floor.transform.parent = transform;
                floor.name = $"{x}-{y}";
                
                floor.transform.localScale *= _scale;
                
                floor.transform.position = new Vector3( (size.x + _offset)*(0.5f+x) , (size.y + _offset)*(0.5f+y),0);
                
                if (_isIso = true)
                {
                    CreateIsoMap(prefab, renderer, x, y);
                }
                
                _map[x, y] = floor;
            }           
        }
    }

    
    private void CreateIsoMap(GameObject platform, SpriteRenderer sprite, int x, int y)
    {
        Destroy(platform.GetComponent<BoxCollider2D>());
        platform.AddComponent<PolygonCollider2D>();

        PolygonCollider2D polygon = platform.GetComponent<PolygonCollider2D>();
        polygon.isTrigger = true;
        //polygon.points = _isoPoints;
        
        _rotX = new Vector2(0.5f * (sprite.bounds.size.x + _offset), 0.25f * (sprite.bounds.size.y + _offset));
        _rotY = new Vector2(-0.5f * (sprite.bounds.size.x + _offset), 0.25f * (sprite.bounds.size.y + _offset));

        Vector2 rotate = (x * _rotX) + (y * _rotY);
        platform.transform.position = rotate;
        
        sprite.sortingOrder = _order;
        _order -= 1;
    }

    public void centerMap()
    {
        
    }
}
