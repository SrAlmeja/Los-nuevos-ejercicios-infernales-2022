using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;


public class NewWander : NewSeek
{
    int randomtimer;
    [SerializeField]GameObject targetFollow;
    [SerializeField] Transform target;

    public float center;
    public float radius;
    public float angle;

    private void Awake()
    {
        randomtimer = Random.Range(2, 5);
    }

    void Start()
    { 
        currentV = Vector3.zero;
        StartCoroutine(TimerForSearch());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 seeking = this.Seek(target.position);
        Vector3 wandering = doWander();

        Vector3 steering = seeking + wandering;
        this.currentV = Vector3.ClampMagnitude(this.currentV + steering * Time.deltaTime, this.speed);
        transform.position += (Vector3)this.currentV * Time.deltaTime;

        targetFollow.transform.localScale = new Vector3(this.radius, 0,this.radius);
        targetFollow.transform.position = transform.position + (this.currentV.normalized * center);
    }


    Vector3 doWander()
    {
        Vector3 distanceCircle = transform.position + (currentV.normalized * center);
        Vector3 myRotation = Quaternion.AngleAxis(angle, Vector3.forward) * currentV.normalized;
        Vector3 target = distanceCircle + (myRotation * radius / 9);

        return Seek(target);
    }

    IEnumerator TimerForSearch()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(randomtimer);
            angle = Random.Range(-180, 180);
        }
    }

}
