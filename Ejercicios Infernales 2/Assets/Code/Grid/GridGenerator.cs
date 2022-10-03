using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private int height, width;
    [SerializeField] GameObject panels;
    GameObject piso;



    // Start is called before the first frame update
    void Start()
    {
        
        int i, j;
        
        for (i = 0; i <height; i++)
        {
            for (j = 0; j < width; j++)
            {
                piso = Instantiate(panels, new Vector3(i+(panels.transform.position.x + 0.5f),0 ,j+(panels.transform.position.z + 0.5f)), transform.rotation);
                piso.name = $"{i}-{j}";
            }
        }
    }
}
