using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NewSeek
{
    public GameObject target;
    
    Vector2 position;
    public Vector2 FrameV;
    Vector2 oldPos;
    
    void Update()
    {
        Vector3 seek = this.Seek(target.transform.position);
        transform.position += ((currentV) * Time.deltaTime);
        Vector3 steering = seek;
        position = target.transform.position;

        this.currentV = Vector3.ClampMagnitude(this.currentV + steering * Time.deltaTime, this.speed);
        transform.position += this.currentV * Time.deltaTime;

        GetMyVelocity();
    }

    void GetMyVelocity()
    {
        Vector3 CurrentFV = ((Vector2)transform.position - oldPos) / Time.deltaTime;
        FrameV = Vector2.Lerp(FrameV, CurrentFV, 0.1f);
        oldPos = transform.position;
    }
}
