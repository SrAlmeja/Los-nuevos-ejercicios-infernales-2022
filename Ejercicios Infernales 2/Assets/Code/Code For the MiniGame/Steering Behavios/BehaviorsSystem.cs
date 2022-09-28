using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BehaviorsSystem : MonoBehaviour
{
    //Seeking Var:
    public float speed;
    Vector3 myPosition;
    Vector3 seekDesiredV;
    public Vector3 currentV;
    Vector3 distance;
    public float slowRadius;
    public float mass;

    //Flee Var:
    Vector3 fleeDesiredV;
    Vector3 fleeDistance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentV = Vector3.zero;
    }

    public Vector3 seek(Vector3 targetPosition)
    {
        Vector3 myPos = new Vector3(transform.position.x,0, transform.position.z);
        Vector3 targetPos = new Vector3(targetPosition.x,0, targetPosition.z);
        //Direction
        distance = (targetPos - myPos);
        if (slowRadius >= distance.magnitude)
        {
            Debug.Log("Area lenta ");
            seekDesiredV = (distance.normalized * (speed * (distance.magnitude/slowRadius)));
        }
        else if(slowRadius < distance.magnitude)
        {Debug.Log("Steering normal");
            seekDesiredV = (distance.normalized * speed);
        }
        Vector3 steering = (seekDesiredV - currentV) / mass;
        
        return steering;
    }

    public Vector3 flee(Vector3 targetPosition)
    {
        Vector3 steering = seek(targetPosition);
        if (slowRadius <= distance.magnitude)
        {
            seekDesiredV = (distance.normalized * speed );
        }
        else if (slowRadius > distance.magnitude)
        {
            seekDesiredV = (distance.normalized * (speed * (distance.magnitude/slowRadius)));
        }
        return steering * (-1);
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
