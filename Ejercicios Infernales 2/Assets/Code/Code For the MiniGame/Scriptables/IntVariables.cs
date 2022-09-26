using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AlmejaStudio/Variables/Int")]
public class IntVariables : ScriptableObject
{
    public string DeveloperDescription;
    public int Value;

    public void SetValue(int value)
    {
        Value = value;
    }
}
