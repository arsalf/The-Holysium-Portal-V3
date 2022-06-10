using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StarterAssets;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private GameObject timelineObject;
    private ThirdPersonController tpController;
    private ThirdPersonAimController tpAimController;
    private Animator playerAnimator;
    private NavMeshAgent agentPlayer;    
    public Transform targetMissionIn;

    private void Awake() 
    {
        timelineObject.SetActive(false);
    }

    private void Start()
    {
        tpController = GetComponent<ThirdPersonController>();
        tpAimController = GetComponent<ThirdPersonAimController>();
        playerAnimator = GetComponent<Animator>();
        agentPlayer = GetComponent<NavMeshAgent>();
        agentPlayer.enabled = false;
    }

    public void setActiveCutscene(bool state)
    {
        tpController.enabled = !state;
        tpAimController.enabled = !state;
        // playerAnimator.enabled = !state;
        // agentPlayer.enabled = !state;
        // agentPlayer.SetDestination(targetMissionIn.position);
        timelineObject.SetActive(state);
    }
}
