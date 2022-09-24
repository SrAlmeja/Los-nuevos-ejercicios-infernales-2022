using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorsSystem : MonoBehaviour
{
    // distance
    [SerializeField] GameObject target;
    Vector3 distance;
    
    //Seek Vars:
    [SerializeField] public float speed, mass;
    Vector3 desiredv;
    Vector3 currentv;
    Vector3 steering;

    //Flee Var;
    [SerializeField] GameObject[] fleeTargets;
    Vector3 fleeDesiredV;
    Vector3 fleeCurrentV;
    Vector3 fleeSteering;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentv = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DistanceCalculation()
    {
        Vector3 myPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y);
        distance = (targetPos - myPos);
    }

    public void Seek()
    {
        DistanceCalculation();
        desiredv = distance.normalized * speed;
        steering = (desiredv - currentv) / mass;

    }

    public void Flee()
    {
        fleeDesiredV = -desiredv;
    }

    public void Arrival()
    {
        
    }

    public void Wander()
    {
        
    }

    public void Pursuit()
    {
        
    }

    public void Evade()
    {
        
    }
}
