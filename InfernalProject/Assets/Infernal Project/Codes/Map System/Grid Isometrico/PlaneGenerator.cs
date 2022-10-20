using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{
    [Header("Board")] 
    public int width, height;
    public int scale;
    public GameObject[,] boardParent;
    public GameObject prefab;

    private float sizeX, sizeY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlaneSpawner()
    {
        boardParent = new GameObject[width, height];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject panel = Instantiate(prefab);
                panel.name = $"{i}-{j}";

                panel.transform.parent = transform;
                panel.transform.localScale *= scale;
                sizeX = panel.transform.localScale.x;
                sizeY = panel.transform.localScale.y;
                panel.transform.position = new Vector3(sizeX * (0.5f + i), sizeY * (0.5f + j), 0);

                boardParent[i, j] = panel;
            }
        }
        
        transform.position = new Vector3(sizeX * (-width / 2), sizeY * (-height / 2), 0);
    }
}
