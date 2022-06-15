using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using StarterAssets;

public class MissionManager : MonoBehaviour
{    
    private LevelLoader levelLoader;

    private void Start()
    {        
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
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
