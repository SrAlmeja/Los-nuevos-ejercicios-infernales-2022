using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REcursion : MonoBehaviour
{
    [SerializeField] int number;
    private void Start()
    {
        Factorial(number);
    }
    
    
    int Factorial(int n)
    {
        Debug.Log(Factorial(n));
        if (n==1)
        {
            return n;
        }
        return Factorial(n*(n-1));
    }
    
    
}