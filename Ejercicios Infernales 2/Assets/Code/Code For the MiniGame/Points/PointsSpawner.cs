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
    
    int countedPoints;

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

    void Update()
    {
        int actualPoints = points.Value;
        countedPoints = 0;
        
        Vector3 vector = SpawnPosition();
        
        if (countedPoints != actualPoints)
        {
            countedPoints ++;
            SpawnPosition();
            TimeToSpawn();
            Debug.Log("Tus puntos actuales son " + actualPoints);
            Debug.Log("Puntos contados " + countedPoints);
        }
    }

    
    public Vector3 SpawnPosition()
    {
        float x = UnityEngine.Random.Range(-20,20);
        float y = UnityEngine.Random.Range(-45,45);
        
        Vector3 vector = new Vector3(x, 0, y);
        
        return vector;
    }

    public void TimeToSpawn()
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
    
    public void MakeDesSpawnWork()
    {
        Vector3 vector = SpawnPosition();
        
        if (points.Value<=10)
        {
            GameObject nnp = ObjectPooler.GetObject(normalPoints);
            nnp.transform.position = vector;
            DesPawn(normalPoints, nnp);
        }
        else if (points.Value>10 && points.Value<=20)
        {
            GameObject nsp = ObjectPooler.GetObject(scurryPoints);
            nsp.transform.position = vector;
            DesPawn(scurryPoints, nsp);
        }
        else if (points.Value>20 && points.Value<=30)
        {
            GameObject nvsp = ObjectPooler.GetObject(veryScurryPoints);
            nvsp.transform.position = vector;
            DesPawn(veryScurryPoints, nvsp);
        }
        else if (points.Value>30 && points.Value<=40)
        {
            GameObject e = ObjectPooler.GetObject(enemies);
            e.transform.position = vector;
            DesPawn(enemies, e);
        }
    }
    
    public void DesPawn(GameObject primitiva, GameObject go)
    {
        ObjectPooler.RecicleObject(primitiva, go);
    }
}
