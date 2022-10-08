using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperListController : MonoBehaviour
{
    [SerializeField] List<List<GameObject>> listaDeObjetos;

    [SerializeField] int[] numberOfElements;
    
    private SuperListSystem _superListSystem;
    int[] count;
    
    void Start()
    {
        _superListSystem = gameObject.GetComponent<SuperListSystem>();
         count = _superListSystem.CountProperty;
        _superListSystem.CountProperty = numberOfElements;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        _superListSystem.Show(count);
    }
}
