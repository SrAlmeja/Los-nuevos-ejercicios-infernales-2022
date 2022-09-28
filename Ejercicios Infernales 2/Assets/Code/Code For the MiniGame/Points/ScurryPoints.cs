using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScurryPoints : BehaviorsSystem
{
    public GameObject targetToFlee;

    private PlayerController _playerController;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 flee = this.flee(targetToFlee.transform.position);
        transform.position += ((currentV) * Time.deltaTime);
        Vector3 steering = flee;

        this.currentV = Vector3.ClampMagnitude(this.currentV + steering * Time.deltaTime, this.speed);
        transform.position += this.currentV * Time.deltaTime;
    }
    
}
