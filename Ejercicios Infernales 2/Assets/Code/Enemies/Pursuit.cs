using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour
{
    [SerializeField] float TConstant;
    
    //Seek
    [SerializeField] GameObject target;
    [SerializeField] float speed, mass;
    private Vector2 myPos, targetPos;
    Vector3 distance;
    Vector3 desiredv;
    Vector3 currentv;
    Vector3 steering;
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoPursuit();
    }
    
    void DoPursuit()
    {
        Vector2 enemyPos = new Vector2(transform.position.x + (currentv.x * TConstant), transform.position.y + (currentv.y * TConstant));
        Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
        //Direction
        distance = (targetPos - enemyPos);
        desiredv = (distance.normalized * speed);
        steering = (desiredv - currentv) / mass;
        currentv += steering * Time.deltaTime;
        transform.position += (currentv * Time.deltaTime);
    }
    
    
}
