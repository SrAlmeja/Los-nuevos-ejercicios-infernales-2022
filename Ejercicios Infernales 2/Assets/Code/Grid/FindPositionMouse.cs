using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPositionMouse : MonoBehaviour
{
    public MeshRenderer objectRender;
    private FloodFill flood;
    [SerializeField] public Material normalMat, redMat, floodMat, choosenMat, ironMat;
    private string[] substrings;
    private int x, y;
    
    // Start is called before the first frame update
    void Start()
    {
        objectRender = GetComponent<MeshRenderer> ();
        objectRender.enabled = true;
        objectRender.material = normalMat;
        flood = GetComponent<FloodFill>();
    }

    // Update is called once per frame
    private void OnMouseOver()
    {
        if (objectRender.material == normalMat) 
        {objectRender.material = ironMat;}
        
        if (flood.enablePlane)
        {
            if (Input.GetMouseButtonDown(0))
            {
                substrings = Regex.Split(this.gameObject.name, "-");
                x = int.Parse(substrings[0]);
                y = int.Parse(substrings[1]);
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    flood.xSeed = x;
                    flood.ySeed = y;
                    hit.collider.gameObject.GetComponent<FindPositionMouse>().objectRender.material = choosenMat;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                hit.collider.gameObject.GetComponent<FindPositionMouse>().objectRender.material = redMat;
            }
        }
    }

    private void OnMouseExit()
    {
        if (objectRender.material == ironMat)
        {
            objectRender.material = normalMat;
        }
    }
}
