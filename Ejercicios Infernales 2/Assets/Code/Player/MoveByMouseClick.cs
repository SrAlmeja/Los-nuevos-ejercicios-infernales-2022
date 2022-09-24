using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByMouseClick : MonoBehaviour
{
    public GameObject targetToMove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Tocar");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                targetToMove.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                Debug.Log(hit);
            }
        }
        
    }
}
