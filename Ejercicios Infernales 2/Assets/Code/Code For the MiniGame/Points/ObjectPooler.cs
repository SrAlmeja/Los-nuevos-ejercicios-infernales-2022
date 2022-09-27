using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private static ObjectPooler Instance;

    static Dictionary<int, Queue<GameObject>> pool = new Dictionary<int, Queue<GameObject>>();
    private static Dictionary<int, GameObject> parents = new Dictionary<int, GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;    
        }
        else
        {
            Destroy(this);
        }

    }

    public static void PreLoad(GameObject objectToPool, int amount )
    {
        int id = objectToPool.GetInstanceID();
        
        GameObject parent = new GameObject();
        parent.name = objectToPool.name + " pool";
        parents.Add(id, parent);
        
        pool.Add(id, new Queue<GameObject>());

        for (int i = 0; i < amount; i++)
        {
            CreateObject(objectToPool);
        }
    }

    static void CreateObject(GameObject objectToPool)
    {
        int id = objectToPool.GetInstanceID();
        
        GameObject go = Instantiate(objectToPool) as GameObject;
        go.transform.SetParent(GetParent(id).transform);
        go.SetActive(false);

        pool[id].Enqueue(go);
    }

    static GameObject GetParent(int parentID)
    {
        GameObject parent;
        parents.TryGetValue(parentID, out parent);

        return parent;
    }

    public static GameObject GetObject(GameObject objectToPool)
    {
        int id = objectToPool.GetInstanceID();

        if (pool[id].Count == 0)
        {
            CreateObject(objectToPool);
        }

        GameObject go = pool[id].Dequeue();
        go.SetActive(true);

        return go;
    }

    public static void RecicleObject(GameObject objectToPool, GameObject objectToRecicle)
    {
        int id = objectToPool.GetInstanceID();

        pool[id].Enqueue(objectToRecicle);
        objectToRecicle.SetActive(false);
    }
    
}
