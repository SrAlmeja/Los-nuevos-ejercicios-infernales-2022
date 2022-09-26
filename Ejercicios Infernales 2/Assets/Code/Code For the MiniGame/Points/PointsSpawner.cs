using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    [SerializeField] GameObject normalPoints;
    [SerializeField] GameObject scurryPoints;
    [SerializeField] GameObject veryScurryPoints;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject followPoints;

    [SerializeField] int sizeNP, sizeSP, sizeVSP, sizeE, sizeFO;

    [SerializeField] IntVariables points;
    

private void Start()
    {
        Vector3 vector = SpawnPosition();
        
        ObjectPooler.PreLoad(normalPoints, sizeNP);
        ObjectPooler.PreLoad(scurryPoints, sizeSP);
        ObjectPooler.PreLoad(veryScurryPoints, sizeVSP);
        ObjectPooler.PreLoad(enemies, sizeE);
        ObjectPooler.PreLoad(followPoints, sizeFO);
        
        GameObject nnp = ObjectPooler.GetObject(normalPoints);
        nnp.transform.position = vector;
    }

    private void Update()
    {
        int actualPoints = points.Value;
        int countedPoints = 0;
        if (countedPoints != actualPoints)
        {
            SpawnPosition();
            countedPoints = actualPoints;
        }

        SpawnPosition();
    }

    
    Vector3 SpawnPosition()
    {
        float x = UnityEngine.Random.Range(-20,20);
        float y = UnityEngine.Random.Range(-45,45);
        
        Vector3 vector = new Vector3(x, 0, y);
        
        return vector;
    }

    void TimeToSpawn()
    {
        Vector3 vector = SpawnPosition();
        
        if (points.Value<=10)
        {
            GameObject nnp = ObjectPooler.GetObject(normalPoints);
            nnp.transform.position = vector;
        }
        else if (points.Value>10 && points.Value<=20)
        {
            GameObject nsp = ObjectPooler.GetObject(scurryPoints);
            nsp.transform.position = vector;
        }
        else if (points.Value>20 && points.Value<=30)
        {
            GameObject nvsp = ObjectPooler.GetObject(veryScurryPoints);
            nvsp.transform.position = vector;
        }
        else if (points.Value>30 && points.Value<=40)
        {
            GameObject e = ObjectPooler.GetObject(enemies);
            e.transform.position = vector;
        }
    }
    
    // private void OnTriggerEnter(GameObject primitive, GameObject go, Collider other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         ObjectPooler.RecicleObject(primitive, go);
    //     }
    // }
}
