using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    //Seek
    
    public GameObject target;
    public float speed;
    
    Vector3 myPosition;
    Vector3 desiredV;
    public Vector3 currentV;
    Vector3 distance;

    public float slowDistance, stopDistance;
    public float mass;

    // Start is called before the first frame update
    void Start()
    {
        currentV = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // public Vector3 Seek()
    // {
    //     Vector3 myPos = new Vector3(transform.position.x, 0, transform.position.z);
    //     Vector3 targetPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);
    //     //Direction
    //     distance = (targetPos - myPos);
    //     desiredV = (distance.normalized * speed);
    //     Vector3 steering = desiredV - currentV;
    // }
}
