using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private int height, width;
    [SerializeField] GameObject panels;
    GameObject piso;
    private float x = 0, y = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <height; i++)
        {
            piso = Instantiate(panels, new Vector3(i+(panels.transform.position.x/3 + 1),0,0), transform.rotation);
            for (int j = 0; j < width; j++)
            {
                piso.name = $"{i}-{j}";
                
                piso = Instantiate(panels, new Vector3(i+(panels.transform.position.x/3 + 1),0 ,j+(panels.transform.position.z/2 + 1)), transform.rotation);
                piso.name = j.ToString();
            }
        }
    }
}
