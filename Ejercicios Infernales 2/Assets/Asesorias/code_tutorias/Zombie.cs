using System;
using UnityEngine;

public class Zombie : GeneralTarget
{
    //Movement Variables
    [SerializeField] private float x, y, z;
    [SerializeField] float speed;
    [SerializeField] float mass;
    //Distance Between Objects
    [SerializeField] GameObject player;
    [SerializeField] private GameObject zombie;
    Vector3 zombiePosition;
    Vector3 playerPosition;
    Vector3 distance;
    // Seeking Behavior
    Vector3 desiredV;
    Vector3 CurrentV;
    Vector3 steering;

    void Update()
    {
        Movement();
    }

    void DistanceDetection()
    {
        zombiePosition = new Vector3(zombie.transform.position.x, zombie.transform.position.y, zombie.transform.position.z);
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        distance = (zombiePosition - playerPosition);
    }

    void SeekPlayer()
    {
        desiredV = ()
    }

    void Movement()
    {
        transform.Translate(((x * speed)* Time.deltaTime),((y * speed)* Time.deltaTime),((z * speed)* Time.deltaTime));
    }
}
