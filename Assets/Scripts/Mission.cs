using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission : MonoBehaviour
{
    public string missionName;
    public string description;
    public string nextSceneName;
    public bool isActive;
    public int reward;
    public Progression[] progress;
}
