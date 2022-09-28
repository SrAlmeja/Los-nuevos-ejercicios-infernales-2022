using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class NewSeek : MonoBehaviour
{
    public float speed;
    
    Vector3 myPosition;
    Vector3 seekDesiredV;
    public Vector3 currentV;
    Vector3 distance;
    
    public float slowRaius;
    
    public float mass;
    void Start()
    {
        currentV = Vector3.zero;
    }
    


    public Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 myPos = new Vector3(transform.position.x,0, transform.position.z);
        Vector3 targetPos = new Vector3(targetPosition.x,0, targetPosition.z);
        //Direction
        distance = (targetPos - myPos);
        if (slowRaius >= distance.magnitude)
        {
            seekDesiredV = ((distance.normalized * speed) * (distance.magnitude/slowRaius));
        }
        else
        {
            seekDesiredV = (distance.normalized * speed);
        }
        Vector3 steering = (seekDesiredV - currentV) / mass;
        
        return steering;
    }
}
