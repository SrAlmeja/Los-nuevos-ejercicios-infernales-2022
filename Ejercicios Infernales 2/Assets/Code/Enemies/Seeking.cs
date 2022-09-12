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
    float xSpeed;
    float ySpeed;
    float distanceSpeed;

    public GameObject enemy;
    public GameObject target;

    public float mass;

    private void Awake()
    {
        //mousPos = Input.mousePosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentv = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Seek();
    }
    
    void Seek()
    {
        Vector2 enemyPos = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
        Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
        //Direction
        distance = (targetPos - enemyPos);
        desiredv = (distance.normalized * speed);
        steering = (desiredv - currentv) / mass;
        currentv += (steering) * Time.deltaTime;
        transform.position += (currentv * Time.deltaTime);
    }
}