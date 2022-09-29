using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPositionMouse : MonoBehaviour
{
    Renderer objectRender;
    [SerializeField] Material normalMat, redMat, floodMat;
    
    // Start is called before the first frame update
    void Start()
    {
        objectRender = GetComponent<Renderer> ();
        objectRender.enabled = true;
        objectRender.sharedMaterial = normalMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Se ha usado el mouse");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                objectRender.sharedMaterial = floodMat;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Se ha usado el mouse");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                objectRender.sharedMaterial = redMat;
            }
        }
        
    }
}
