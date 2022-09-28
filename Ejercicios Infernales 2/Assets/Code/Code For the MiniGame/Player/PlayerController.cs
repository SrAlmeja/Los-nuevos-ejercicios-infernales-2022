using UnityEngine;

public class PlayerController : BehaviorsSystem
{
    public GameObject target;

    PointsSpawner _pointsSpawner;
    // Start is called before the first frame update
    private void Start()
    {
        _pointsSpawner = GetComponent<PointsSpawner>();
    }

    private void Update()
    {
        Move();
        _pointsSpawner.TargetsSpawnerPosition();
    }


    void Move()
    {
        Vector3 seek = this.seek(target.transform.position);
        transform.position += ((currentV) * Time.deltaTime);
        Vector3 steering = seek;

        this.currentV = Vector3.ClampMagnitude(this.currentV + steering * Time.deltaTime, this.speed);
        transform.position += this.currentV * Time.deltaTime;
    }
    
    
    
}
