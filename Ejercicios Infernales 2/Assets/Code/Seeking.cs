using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Seeking : MonoBehaviour
{
    // private Camera cam;
    // Vector2 mousPos;
    // Vector2 enemyPos;
    
    Vector3 distance; 
    public float speed;
    Vector3 desiredv;
    Vector3 currentv;
    Vector3 steering;

    public GameObject enemy;
    public GameObject target;
    
    private void Awake()
    {
        //mousPos = Input.mousePosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentv = Vector3.zero;
        //cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        TheCameraFunction();
        SeekingAlgorithm();
    }

    void TheCameraFunction()
    {
        // Vector3 point = new Vector3();
        // Event currentEvent = Event.current;
        // mousPos = new Vector2();
        // mousPos.x = currentEvent.mousePosition.x;
        // mousPos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        // point = cam.ScreenToWorldPoint(new Vector3(mousPos.x, mousPos.y, cam.nearClipPlane));
        // GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        // GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        // GUILayout.Label("Mouse position: " + mousPos);
        // GUILayout.Label("World position: " + point.ToString("F3"));
        // GUILayout.EndArea();
    }

    void Seek()
    {
        Vector2 enemyPos = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
        Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
        distance = (enemyPos - targetPos);
        desiredv = (distance.normalized * speed);
        steering = (desiredv - currentv);
        currentv += steering * Time.deltaTime;
        transform.position += (currentv * Time.deltaTime);
        

    }
    void SeekingAlgorithm()
    {
        // distance = (mousPos - enemyPos);
        // currentv = Vector3.zero;
        
    }
}
