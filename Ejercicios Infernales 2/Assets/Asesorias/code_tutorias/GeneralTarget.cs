using System;
using Unity.VisualScripting;
using UnityEngine;
public class GeneralTarget : MonoBehaviour
{
    [SerializeField] float HP = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere")
        {
            GetDamage(1);
            Debug.Log("Me esta tocado la " + other);
        }
    }

    void GetDamage(float amount)
    {
        HP -= amount;
        if (HP <= 0)
        {
            YouAreDead();    
        }
        
    }

    void YouAreDead()
    {
       Debug.Log("Me han matado " + transform.name);
    }
}
