using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFlee : NewSeek
{
    NewSeek newSeek;
    void Star()
    {
        newSeek = GetComponent<NewSeek>();
        newSeek.currentV = Vector3.zero;
    }

    void Update()
    {
        newSeek.Seek();
        transform.position -= (currentV * Time.deltaTime);
    }
    
}
