using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFlee : NewSeek
{
    Vector3 fleeDesiredV;
    Vector3 fleeDistance;
    
    void Star()
    {
        currentV = Vector3.zero;
    }
    
    
    public Vector3 Flee(Vector3 targetPosition)
    {
        Vector3 steering = Seek(targetPosition);
        return steering * (-1);
    }
    
}
