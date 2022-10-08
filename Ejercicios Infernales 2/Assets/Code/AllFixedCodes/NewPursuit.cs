using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class NewPursuit : NewSeek
{
    Vector3 playersFrameVelocity; 
    Vector3 oldPos; 
    Vector3 futurePos;
    [SerializeField] float tConstant;
    [SerializeField] bool isDinamic;

    [SerializeField] GameObject target;
    [SerializeField] bool evade;

    MoveByMouse player;
    NewFlee flee;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<MoveByMouse>();
        flee = GetComponent<NewFlee>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDinamic)
        {
            this.tConstant = (target.transform.position - transform.position).magnitude / this.speed;
        }

        futurePos = target.transform.position + (Vector3)player.FrameV * this.tConstant;

        Vector3 seek = Pursuit(futurePos);
        if (evade)
        {
            seek = this.flee.Flee(futurePos);
        }

        Vector3 steering = seek;
        currentV = Vector3.ClampMagnitude(currentV + steering * Time.deltaTime, speed);
        transform.position += (Vector3)currentV * Time.deltaTime;
        
    }

    public Vector3 Pursuit(Vector3 targetPosition)
    {
        Vector3 currentPV = (targetPosition - oldPos) / Time.deltaTime;
        playersFrameVelocity = Vector3.Lerp(playersFrameVelocity, currentPV, 0.1f);
        oldPos = targetPosition;

        if (isDinamic)
        {
            tConstant = (targetPosition - transform.position).magnitude / speed;
        }

        futurePos = targetPosition + (playersFrameVelocity * tConstant);
        return Seek(futurePos);
    }
}
