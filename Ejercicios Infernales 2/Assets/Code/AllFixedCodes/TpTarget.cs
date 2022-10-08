using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TpTarget : MonoBehaviour
{ 
    int timeToTP;

    private void Awake()
    {
        timeToTP = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TP(timeToTP));
    }

    IEnumerator TP(int newRandom)
    {
        while (true)
        {
            yield return new WaitForSeconds(newRandom);
            transform.position = new Vector3(Random.Range(-8, 8), 0, Random.Range(-4, 4));
            newRandom = Random.Range(2, 5);
        }
    }
}
