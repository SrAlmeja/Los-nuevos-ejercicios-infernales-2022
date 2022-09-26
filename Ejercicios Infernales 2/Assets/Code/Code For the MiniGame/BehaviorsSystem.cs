using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorsSystem : MonoBehaviour
{
    //Seeking Var:
    public float speed;
    Vector3 myPosition;
    Vector3 desiredV;
    Vector3 currentV;
    Vector3 distance;
    public float slowDistance, stopDistance;
    public float mass;

    //Flee Var:
    [SerializeField] GameObject[] fleeTargets;
    Vector3 fleeDesiredV;
    Vector3 fleeCurrentV;
    Vector3 fleeSteering;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentV = Vector3.zero;
    }

    public Vector3 doSeek(Vector3 targetPosition)
    {
        distance = (targetPosition - transform.position);
        desiredV = (distance.normalized * speed);
        Vector3 steering = ((desiredV - currentV) / mass);
        currentV += (steering) * Time.deltaTime;

        return steering;
    }

    // public Vector3 doFlee()
    // {
    //     fleeDesiredV = -desiredV;
    // }

    public Vector3 doArrival(Vector3 targetPosition)
    {
        Vector3 steering = doSeek(targetPosition);
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

        return steering;
    }

//     public Vector3 doWander()
//     {
//         
//     }
//
//     public Vector3 doPursuit()
//     {
//         
//     }
//
//     public Vector3 doEvade()
//     {
//         
//     }
}
