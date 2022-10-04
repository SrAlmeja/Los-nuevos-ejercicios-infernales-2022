using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPositionMouse : MonoBehaviour
{
    public MeshRenderer objectRender;
    [SerializeField] Material normalMat, redMat, floodMat;
    
    // Start is called before the first frame update
    void Start()
    {
        objectRender = GetComponent<MeshRenderer> ();
        objectRender.enabled = true;
        objectRender.material = normalMat;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Se ha usado el mouse");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                hit.collider.gameObject.GetComponent<FindPositionMouse>().objectRender.material = floodMat;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Se puso obstaculo");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                hit.collider.gameObject.GetComponent<FindPositionMouse>().objectRender.material = redMat;
            }
        }
    }
}
