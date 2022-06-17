using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void MissionPressKey(string keyName, int kodeIndex)
    {
        progress[kodeIndex].pressKeyInstruction(keyName);        

        //remove progress
        // progress = progress.Where((source, index) =>index != kodeIndex).ToArray();
    }    

}
