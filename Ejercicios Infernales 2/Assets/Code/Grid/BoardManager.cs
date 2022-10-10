using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardManager : MonoBehaviour
{
    [SerializeField] public int height, width;
    [SerializeField] int scale;
    public GameObject[,] planeParemt;
    public GameObject piso;

    private float sizeX, sizeY;
    
    void Start()
    {
        PanelsGenerator();
    }

    public void PanelsGenerator()
    {
        planeParemt = new GameObject[height, width];
        
        
        for (int i = 0; i <height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject thePlane = Instantiate(piso);
                thePlane.name = $"{i}-{j}";
                
                thePlane.transform.parent = transform;
                thePlane.transform.localScale *= scale;
                sizeX = thePlane.transform.localScale.x;
                sizeY = thePlane.transform.localScale.y;
                thePlane.transform.position = new Vector3(sizeX + (0.5f + i),0,sizeY + (0.5f + j));

                planeParemt[i, j] = thePlane;

            }
        }

        transform.position = new Vector3(sizeX * (-height / 2), sizeY * (-width / 2), 0);
    }
}
