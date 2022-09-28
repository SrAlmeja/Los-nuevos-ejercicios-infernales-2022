using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PointsSpawner : MonoBehaviour
{
    [SerializeField] GameObject normalPoints;
    [SerializeField] GameObject scurryPoints;
    [SerializeField] GameObject veryScurryPoints;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject followPoints;

    [SerializeField] GameObject pointTargets;

    [SerializeField] int sizeNP, sizeSP, sizeVSP, sizeE, sizeFO, sizePT;

    [SerializeField] IntVariables points;

    [SerializeField] GameObject spawnerOfTargets;

    [SerializeField] BoolVariable timerBoolNP, timerBoolSP, timerBoolVSP, timerBoolE, timerBoolFO, timerBoolPT; 

    int countedPoints;
    float timeToDie = 0.1f;
    float infiniteTime = 9999999999;
    float finalClockNP, finalClockSP, finalClockVSP;
    float finalClockE, finalClockFO, finalClockPT;

    private NewSeek _newSeek;

    private void Awake()
    {
        _newSeek = GetComponent<NewSeek>();
    }

    private void Start()
    {
        Vector3 vector = SpawnPosition();
        
        ObjectPooler.PreLoad(normalPoints, sizeNP);
        ObjectPooler.PreLoad(scurryPoints, sizeSP);
        ObjectPooler.PreLoad(veryScurryPoints, sizeVSP);
        ObjectPooler.PreLoad(enemies, sizeE);
        ObjectPooler.PreLoad(followPoints, sizeFO);
        ObjectPooler.PreLoad(pointTargets, sizePT);
        
        GameObject nnp = ObjectPooler.GetObject(normalPoints);
        nnp.transform.position = vector;
        
        countedPoints = 0;
    }

private void Update()
{
    int actualPoints = points.Value;
    if (actualPoints > countedPoints)
    {
        SpawnPosition();
        TimeToSpawn();
        countedPoints ++;
        SpawnFO();
    }
}

public Vector3 SpawnPosition()
    {
        float x = Random.Range(-20,20);
        float y = Random.Range(-45,45);
        
        Vector3 vector = new Vector3(x, 0, y);
        
        return vector;
    }

public Vector3 TargetsSpawnerPosition()
{
    Vector3 STPosition = spawnerOfTargets.transform.position;
    Vector3 vector = new Vector3((STPosition.x+0.5f), (STPosition.y + 0.5f), (STPosition.z + 0.5f));
    return vector;
}

    public void TimeToSpawn()
    {
        Vector3 vector = SpawnPosition();
        TimeToDieFunction();

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

    public void SpawnFO()
    {
        int actualPoints = points.Value;
        Vector3 vector = TargetsSpawnerPosition();
        if (actualPoints > countedPoints)
        {
            GameObject FP = ObjectPooler.GetObject(followPoints);
            FP.transform.position = vector;
        }

        GameObject SOT = ObjectPooler.GetObject(spawnerOfTargets);
        SOT.transform.position = vector;
        StartCoroutine(DesPawn(spawnerOfTargets, SOT, 4f));

    }
    
    public void MakeDesSpawnWork()
    {
        Vector3 vector = SpawnPosition();
        
        if (points.Value<=10)
        {
            GameObject nnp = ObjectPooler.GetObject(normalPoints);
            nnp.transform.position = vector;
            DesPawn(normalPoints, nnp, finalClockNP);
        }
        else if (points.Value>10 && points.Value<=20)
        {
            GameObject nsp = ObjectPooler.GetObject(scurryPoints);
            nsp.transform.position = vector;
            DesPawn(scurryPoints, nsp, finalClockSP);
        }
        else if (points.Value>20 && points.Value<=30)
        {
            GameObject nvsp = ObjectPooler.GetObject(veryScurryPoints);
            nvsp.transform.position = vector;
            DesPawn(veryScurryPoints, nvsp, finalClockVSP);
        }
        else if (points.Value>30 && points.Value<=40)
        {
            GameObject e = ObjectPooler.GetObject(enemies);
            e.transform.position = vector;
            DesPawn(enemies, e, finalClockE);
        }
    }
    
    
    IEnumerator DesPawn(GameObject primitiva, GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPooler.RecicleObject(primitiva, go);
    }
    
    
    public void TimeToDieFunction()
    {
        if (!timerBoolNP)
        {
            finalClockNP = timeToDie;
            timerBoolNP.Value = true;
        }else { finalClockNP = infiniteTime;}
        if (!timerBoolSP)
        {
            finalClockSP = timeToDie;
            timerBoolNP.Value = true;
        }else { finalClockSP = infiniteTime; }
        if (!timerBoolVSP)
        {
            finalClockVSP = timeToDie;
            timerBoolVSP.Value = true;
        }
        else { finalClockVSP = infiniteTime; }
        if (!timerBoolE)
        {
            finalClockE = timeToDie;
            timerBoolE.Value = true;
        }else { finalClockE = infiniteTime; }
        if (!timerBoolFO)
        {
            finalClockFO = timeToDie;
            timerBoolFO.Value = true;
        } else { finalClockFO = infiniteTime; }
        if (!timerBoolPT)
        {
            finalClockPT = timeToDie;
            timerBoolPT.Value = true;
        }else { finalClockPT = infiniteTime; }
    }
    
}
