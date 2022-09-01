using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    Vector3 distance; 
    public float speed;
    Vector3 desiredv;
    Vector3 currentv;
    Vector3 steering;
    float xSpeed;
    float ySpeed;
    float distanceSpeed;
    float closerDistanceE;
    float closerDistanceW;
    float enemyDistance;
    float wallsDistance;
    int closerEnemy = 0;
    int closerWall = 0;
    

    public GameObject [] enemies;
    public GameObject[] walls;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentv = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        CloserObjects();
        Seek();
    }

    void CloserObjects()
    {
        //Enemies
        closerDistanceE = Vector3.Distance(transform.position, enemies[0].transform.position);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyDistance = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (enemyDistance <= closerDistanceE)
            {
                closerDistanceE = enemyDistance;
                closerEnemy = i;
            }
        }
        //Walls
        closerDistanceW = Vector3.Distance(transform.position, walls[0].transform.position);
        for (int i = 0; i < walls.Length; i++)
        {
            wallsDistance = Vector3.Distance(transform.position, walls[i].transform.position);
            if (wallsDistance <= closerDistanceW)
            {
                closerDistanceW = wallsDistance;
                closerWall = i;
            }
        }
    }
    
    void Seek()
    {
        //flee enemies Position
        Vector2 enemyPos = new Vector2(enemies[closerEnemy].transform.position.x, enemies[closerEnemy].transform.position.y);
        Vector2 targetPos = new Vector2(player.transform.position.x, player.transform.position.y);
        //Direction
        distance = (targetPos - enemyPos);
        desiredv = (distance.normalized * speed);
        steering = (desiredv - currentv);
        currentv += steering * Time.deltaTime;
        transform.position += (currentv * Time.deltaTime);
        //flee enemies Position
        Vector2 wallsPos = new Vector2(walls[closerWall].transform.position.x, walls[closerWall].transform.position.y);
        //Direction
        distance = (targetPos - wallsPos);
        desiredv = (distance.normalized * speed);
        steering = (desiredv - currentv);
        currentv += steering * Time.deltaTime;
        transform.position += (currentv * Time.deltaTime);
    }
}
