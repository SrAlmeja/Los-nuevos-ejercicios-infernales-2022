using System;
using UnityEngine;

public class Zombie : GeneralTarget
{
    [SerializeField] private float x, y, z;
    [SerializeField] float speed;
    //Distance Between Objects
    [SerializeField] GameObject player;
    [SerializeField] private GameObject zombie;
    private Vector3 zombiePosition;
    private Vector3 playerPosition;
    private Vector3 distance;
    void Update()
    {
        Movement();
    }

    void DistanceDetection()
    {
        zombiePosition = new Vector3(zombie.transform.position.x, zombie.transform.position.y, zombie.transform.position.z);
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        distance = new Vector3((zombiePosition.x - playerPosition.x), (zombiePosition.y - playerPosition.y), (zombiePosition.z - playerPosition.z));
    }

    void Movement()
    {
        transform.Translate(((x * speed)* Time.deltaTime),((y * speed)* Time.deltaTime),((z * speed)* Time.deltaTime));
    }
}
