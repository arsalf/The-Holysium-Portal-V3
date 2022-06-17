using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using StarterAssets;

public class MissionManager : MonoBehaviour
{    
    public LevelLoader levelLoader;    
	public string[] instructionsText;	

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		
	}

	void checkInstructionDone()
	{

	}

    void OnTriggerEnter(Collider other)
	{			
		Mission _mission = other.GetComponent<Mission>();

		if(_mission != null)
		{			
			Debug.Log("hit mission info : "+_mission.missionName);            

            levelLoader.LoadNextScene(_mission.nextSceneName);
            // SceneManager.LoadScene("Scenes/Maintanance");
		}
	}
}
