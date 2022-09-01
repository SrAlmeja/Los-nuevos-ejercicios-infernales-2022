using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AlmejaStudio/Variable/Bool")]
public class BoolVariable : ScriptableObject
{
    public string DeveloperDescription;
    public bool Value;

    public void SetValue(bool value)
    {
        Value = value;
    }
}
