using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class NewSeek : MonoBehaviour
{
    public GameObject Me;
    public GameObject Target;

    private Vector3 velocity;
    public float maxVel;
    private Vector3 myPosition;
    private Vector3 desiredV;
    private Vector3 steering;
    private Vector3 currentV;
    private Vector3 distance;

    Vector3 truncate;
    public int maxForce;
    public float mass;
    public float maxSpeed;
    void Start()
    {
        currentV = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Seek();
    }

    void Seek()
    {
        Vector2 enemyPos = new Vector2(Me.transform.position.x + velocity.x, Me.transform.position.y + velocity.y);
        Vector2 targetPos = new Vector2(Target.transform.position.x, Target.transform.position.y);

        distance = (targetPos - enemyPos);

        desiredV = (distance.normalized * maxVel);
        steering = desiredV - velocity;

        truncate = new Vector3(steering.x, maxForce, 0);
        steering = truncate;
        steering = steering / mass;

        truncate = new Vector3((velocity.x + steering.x), maxSpeed, 0);
        velocity = truncate;
        transform.position += (steering * Time.deltaTime);
    }
}
