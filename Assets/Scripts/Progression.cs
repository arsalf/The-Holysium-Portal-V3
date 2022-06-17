using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progression : MonoBehaviour
{
    public string instructionName;
    public bool isDone;
    
    public void pressKeyInstruction(string key)
    {
        if(Input.GetKeyDown(key))
        {
            isDone = true;
        }
    }
}
