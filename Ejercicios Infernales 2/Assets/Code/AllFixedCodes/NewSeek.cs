using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class NewSeek : MonoBehaviour
{
    
    public GameObject target;
    public float speed;
    
    Vector3 myPosition;
    Vector3 desiredV;
    Vector3 steering;
    Vector3 currentV;
    Vector3 distance;

    public float slowDistance, stopDistance;
    
    
    
    public float mass;
    void Start()
    {
        currentV = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Seek();
    }

    
    void Seek()
    {
        Vector3 myPos = new Vector3(transform.position.x,0, transform.position.z);
        Vector3 targetPos = new Vector3(target.transform.position.x,0, target.transform.position.z);
        //Direction
        distance = (targetPos - myPos);
        desiredV = (distance.normalized * speed);
        steering = ((desiredV - currentV) / mass);
        currentV += (steering) * Time.deltaTime;

        if (distance.magnitude > slowDistance)
        {
            currentV = currentV * 1 ;
        }
        else if (distance.magnitude <= slowDistance)
        {
            currentV = steering * 0.5f;
        }
        else if (distance.magnitude <= stopDistance)
        { 
            currentV = steering * 0f;
        }
        Debug.Log(currentV);
        transform.position += ((currentV) * Time.deltaTime);
    }
}
