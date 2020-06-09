using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective
{
    public bool isActive;
    [TextArea(3,10)]
    public string goalDescription;
}
