using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]  private Vector2 size;
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool isIso;
    [SerializeField] private float Offset;
    private Color selectedBlock;
    private Color startColor;
    private Color endColor;
    [SerializeField] private bool _goalSelected;
    //private Fields _fields;
    private Map _m;

    private void Awake()
    {
        _m = GetComponent<Map>();
        _m.CreateMap(prefab);
    }

    
    void Start()
    {
        
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
