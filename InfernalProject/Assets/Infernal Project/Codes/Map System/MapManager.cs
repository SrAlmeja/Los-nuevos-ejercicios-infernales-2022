using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;
    [SerializeField] private float _scale;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool _isIso;
    [SerializeField] private float _Offset;
    private Color selectedBlock;
    private Color startColor;
    private Color endColor;
    [SerializeField] private bool _goalSelected;
    //private Fields _fields;
    private Map _m;

    private void Awake()
    {
        _m = GetComponent<Map>();
        _m.CreateMap(_prefab);

        _m.Width = _size.x;
        _m.Height = _size.y;
        _m.Prefab = _prefab;
        _m.IsIso = _isIso;
        _m.Scale = _scale;
        _m.Offset = _Offset;
    }

    
    void Start()
    {
        _m.CreateMap(_prefab);
    }
    
    void Update()
    {
    }

    public void RestartMap()
    {
        
    }

    public Vector2 updatePoints(Vector2 theVector, int theInt)
    {
        return theVector;
    }
    
    public Vector2 updateObstacles(Vector2 theVector, int theInt)
    {
        return theVector;
    }
}
