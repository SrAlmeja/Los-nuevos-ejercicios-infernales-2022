using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Seeking
{
    public GameObject circle;
    public Vector2 velocity = Vector3.zero;
    public Vector2 randomTarget;
    public float speed;
    public float circleDistance;
    public float radius;
    LineRenderer disCircle;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(updateTarget());
        randomTarget = new Vector3(Random.Range(-8f, 8f), Random.Range(-5f, 5));
        disCircle = gameObject.GetComponent<LineRenderer>();
    }

    IEnumerator updateTarget()
    {
        while(true)
    {
        yield return new WaitForSeconds(10);
        randomTarget = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, 2f));
    }
    }
    
    void Update()
    {
        Seek(randomTarget);
        WanderFunction();
    }

    void Seek(Vector3 posTarget)
    {
        Vector2 distanceV = posTarget - (Vector3)transform.position;
        Vector2 desiredVel = distanceV.normalized * speed;
        Vector2 sterring = desiredVel - velocity;

        velocity += sterring * Time.deltaTime;
        transform.position += (Vector3)velocity;
    }

    void WanderFunction()
    {
        //Calcular la posición del circulo
        Vector2 distanceCircle = velocity.normalized * circleDistance;
        //Obtiene el vector Radio (Rotado)
        Vector2 radiusV = distanceCircle + (velocity.normalized * radius);
        //Obtener la fuerza Steering
        Vector2 sterring = distanceCircle + radiusV;
        //Actualizar posicion y movimiento
        velocity += sterring * Time.deltaTime;
        transform.position += (Vector3)velocity * Time.deltaTime;
        //Actualizar circulo
        circle.transform.localScale = new Vector3(radius, radius, 0);
        circle.transform.position = (Vector2)transform.position + (velocity.normalized * circleDistance);
        


    }

    
    
}
