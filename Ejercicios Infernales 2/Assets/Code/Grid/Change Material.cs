using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ChangeMaterial : MonoBehaviour
{
    Renderer objectRender;
    [SerializeField] Material normalMat, redMat, floodMat;
    GameObject plano;
    
    // Start is called before the first frame update
    void Start()
    {
        plano = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/Grid/Cell.Name.prefab");
        objectRender = GetComponent<Renderer> ();
        objectRender.enabled = true;
        objectRender.sharedMaterial = normalMat;
    }

    // Update is called once per frame
    void Update()
    {
        
                objectRender.sharedMaterial = floodMat;
   
                objectRender.sharedMaterial = redMat;
                
        
    }
}