using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByMouse : MonoBehaviour
{
    Camera cam;
    
    public Vector3 FrameV;
    Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector3)cam.ScreenToWorldPoint(Input.mousePosition);
        MyFrameV();
    }
    
    void MyFrameV()
    {
        Vector3 currentFrameV = ((Vector3)transform.position - oldPos / Time.deltaTime);
        FrameV = Vector3.Lerp(FrameV, currentFrameV, 0.1f);
        oldPos = transform.position;
    }
}
