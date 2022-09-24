using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    //Seek
    [SerializeField] GameObject target;
    [SerializeField] float speed, mass;
    private Vector2 myPos, targetPos;
    Vector3 distance;
    Vector3 desiredv;
    Vector3 currentv;
    Vector3 steering;
    
    //Wander
    [SerializeField] float angleLoop, distanceCenter, radius, angle = 0;
    [SerializeField] float SpawnTime;
    float elapsedTime;

    void Awake()
    {
        Instantiate(target, transform.position, transform.rotation);
    }
    

    void Update()
    {
        myPos = new Vector2(transform.position.x, transform.position.y);
        targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
        Seek();
        for (int i = 0; i < SpawnTime; i++)
        {
            
        }
        Debug.Log(distance);
    }

    void Seek()
    {
        //Direction
        distance = (targetPos - myPos);
        desiredv = (distance.normalized * speed);
        steering = (desiredv - currentv) / mass;
        currentv += steering * Time.deltaTime;
        transform.position += (currentv * Time.deltaTime);
    }

    void DoWander()
    {
        Vector3 distanceCircle = transform.position + (currentv.normalized * distanceCenter);
        Vector3 rotated = Quaternion.AngleAxis(angle, Vector3.forward) * currentv.normalized;
        Vector3 target = distanceCircle + (rotated * radius/8.1f);
        
    }
}
