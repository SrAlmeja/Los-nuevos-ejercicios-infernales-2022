using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int _x, _y;
    private SpriteRenderer _render;
    private Color _color;
    private MapManager _manager;
    private int _obstacle;
    private int _moveCoast;

    public int X
    {
        get { return _x; }
        set { _x = value; }
    }
    
    public int y
    {
        get { return _y; }
        set { _y = value; }
    }
    
    private void Awake()
    {
        
    }
    

    public void OnMouseOver()
    {
        throw new NotImplementedException();
    }

    public void OnMouseExit()
    {
        throw new NotImplementedException();
    }
}
