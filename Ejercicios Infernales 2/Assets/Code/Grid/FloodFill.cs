using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFill : MonoBehaviour
{
    public float planeDelay;
    private BoardManager boardManager;
    private FindPositionMouse fPM;

    public int xSeed, ySeed;
    public bool enablePlane;
    public bool queuePlane;

    private GameObject[,] plane;
    
    // Start is called before the first frame update
    void Start()
    {
        fPM = GetComponent<FindPositionMouse>();
        boardManager = GetComponent<BoardManager>();
        enablePlane = true;
    }

    // Update is called once per frame
    void Update()
    {   
        foreach (var piso in boardManager.planeParemt)
        {
            MeshRenderer myMeshpiso = piso.GetComponent<MeshRenderer>();
            if (myMeshpiso.material == fPM.normalMat)
            {
                enablePlane = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (!queuePlane)
            {
                StartCoroutine(Flood(xSeed, ySeed));
            }

            if (queuePlane)
            {
                StartCoroutine(FloodQueue(new Vector3(xSeed, 0, ySeed)));
            }
        }
    }

    IEnumerator Flood(int x, int y)
    {
        WaitForSeconds timeToWait = new WaitForSeconds(planeDelay);

        if (x >= 0 && x < boardManager.height && y < boardManager.width)
        {
            yield return timeToWait;
            MeshRenderer currentMat = boardManager.piso.GetComponent<MeshRenderer>();
            if (currentMat == fPM.normalMat || currentMat == fPM.choosenMat)
            {
                currentMat.material = fPM.floodMat;
                StartCoroutine(Flood(x + 1, y));
                StartCoroutine(Flood(x - 1, y));
                StartCoroutine(Flood(x, y +1));
                StartCoroutine(Flood(x - 1, y));

            }
        }
    }

    IEnumerator FloodQueue(Vector3 floodedPanel)
    {
        Queue<Vector3> flooded = new Queue<Vector3>();
        flooded.Enqueue(floodedPanel);
        while (flooded.Count > 0)
        {
            floodedPanel = flooded.Dequeue();
            if (floodedPanel.x > 0 && floodedPanel.x < boardManager.height && floodedPanel.y  >= 0 && floodedPanel.y < boardManager.width)
            {
                MeshRenderer currentMat = boardManager.planeParemt[(int)floodedPanel.x, (int)floodedPanel.y].GetComponent<MeshRenderer>();
                yield return new WaitForSeconds(planeDelay);

                if (currentMat.material == fPM.normalMat || currentMat.material == fPM.choosenMat)
                {
                    currentMat.material = fPM.floodMat;
                    if (floodedPanel.x + 1 < boardManager.height) flooded.Enqueue(new Vector2((floodedPanel.x + 1), floodedPanel.y));
                    if (floodedPanel.x - 1 <= boardManager.height) flooded.Enqueue(new Vector2((floodedPanel.x - 1), floodedPanel.y));
                    if (floodedPanel.y + 1 < boardManager.width) flooded.Enqueue(new Vector2(floodedPanel.x, (floodedPanel.y + 1)));
                    if (floodedPanel.y - 1 <= boardManager.width) flooded.Enqueue(new Vector2(floodedPanel.x,(floodedPanel.y - 1)));
                }

            }
        }
    }
}
