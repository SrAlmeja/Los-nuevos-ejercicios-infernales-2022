using UnityEngine;

public class PlayerController : BehaviorsSystem
{
    public GameObject target;
    PointsSpawner _pointsSpawner;

    public Vector3 FrameV;
    Vector3 oldPos;
    
    // Start is called before the first frame update
    private void Start()
    {
        _pointsSpawner = GetComponent<PointsSpawner>();
    }

    private void Update()
    {
        Move();
        _pointsSpawner.TargetsSpawnerPosition();
        
        MyFrameV();
    }


    void Move()
    {
        Vector3 seek = this.seek(target.transform.position);
        transform.position += ((currentV) * Time.deltaTime);
        Vector3 steering = seek;

        this.currentV = Vector3.ClampMagnitude(this.currentV + steering * Time.deltaTime, this.speed);
        transform.position += this.currentV * Time.deltaTime;
    }

    void MyFrameV()
    {
        Vector3 currentFrameV = ((Vector3)transform.position - oldPos / Time.deltaTime);
        FrameV = Vector3.Lerp(FrameV, currentFrameV, 0.1f);
        oldPos = transform.position;
    }
    
    
}
