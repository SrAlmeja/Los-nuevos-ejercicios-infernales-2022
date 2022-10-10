using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class NewPursuit : NewSeek
{
    public bool isDynamic;
    Vector3 playersFrameVelocity; 
    Vector3 oldPos; 
    Vector3 futurePos;
    public float tConstant;
    
    public float maxSeeAhead;
    public float maxAvoidForce;
    public GameObject avoidGameObject;
    
    public GameObject target;    
    public bool evade;

    Player player;

    NewFlee flee;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        flee = GetComponent<NewFlee>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isDynamic)
        {
            tConstant = (target.transform.position - transform.position).magnitude / speed;
        }
        
        futurePos = target.transform.position + (Vector3)player.FrameV * this.tConstant;
        
        Vector3 seek = doPursuit(futurePos);
        if(evade)
        {
            seek = this.flee.Flee(futurePos);
        }

        Vector3 steering = seek;
        currentV = Vector3.ClampMagnitude(currentV + steering * Time.deltaTime, speed);
        transform.position += (Vector3)currentV * Time.deltaTime;
        
    }

    public Vector3 doPursuit(Vector3 targetPosition)
    {
        Vector3 currentPlayerVelocity = (targetPosition - oldPos) / Time.deltaTime;
        playersFrameVelocity = Vector3.Lerp(playersFrameVelocity, currentPlayerVelocity, 0.1f);
        oldPos = targetPosition;
    
        if(isDynamic)
        {
            tConstant = (targetPosition - transform.position).magnitude / speed;
        }
    
        futurePos = targetPosition + (playersFrameVelocity * tConstant);
        return Seek(futurePos);
    }
}
