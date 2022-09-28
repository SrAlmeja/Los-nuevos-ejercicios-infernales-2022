using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] IntVariables points;
    public TextMeshProUGUI pointsText;
    PointsSpawner _pointsSpawner;

    [SerializeField] BoolVariable timerBoolNP, timerBoolSP, timerBoolVSP;
    [SerializeField] BoolVariable timerBoolE, timerBoolFO, timerBoolPT; 
    
    private void Awake()
    {
        _pointsSpawner = GetComponent<PointsSpawner>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        points.Value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points.Value = Mathf.Clamp(points.Value, 00, 40);
        pointsText.text = points.Value.ToString();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NormalPoints"))
        {
            points.Value ++;
            timerBoolNP.Value = false;
        }
        if (other.gameObject.CompareTag("ScurryPoints"))
        {
            points.Value ++;
            timerBoolSP.Value = false;
        }
        if (other.gameObject.CompareTag("VeryScurryPoints"))
        {
            points.Value ++;
            timerBoolVSP.Value = false;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            points.Value --;
            timerBoolE.Value = false;
        }
        if (other.gameObject.CompareTag("TargetPoint"))
        {
            _pointsSpawner.SpawnFO();
            timerBoolPT.Value = false;
        }
    }
}
