using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public enum ComboState {
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3    
}

public class ThirdPersonFighterController : MonoBehaviour
{
    // [SerializeField] private float normalSensitivity = 1f;
    // [SerializeField] private float aimSensitivity = .1f;

    private StarterAssetsInputs starterAssetInputs;
    private Animator animator;
    private ThirdPersonController thirdpersonController;
    private bool activeTimerToReset;
    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;
    private float normalMoveSpeed;
    private float normalSprintSpeed;

    private ComboState currentComboState;

    private void Awake()
    {
        starterAssetInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        thirdpersonController = GetComponent<ThirdPersonController>();
    }

    private void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
        normalMoveSpeed = thirdpersonController.MoveSpeed;
        normalSprintSpeed = thirdpersonController.SprintSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttack();
        ResetComboState();
    }

    void ComboAttack()
    {
        if(starterAssetInputs.combat && !starterAssetInputs.aim)
        {
            currentComboState++;
            activeTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            thirdpersonController.SetMoveSpeed(0f);
            thirdpersonController.SetSprintSpeed(0f);

            if(currentComboState == ComboState.PUNCH_1)
            {
                animator.SetTrigger("Punch1");
            }
            
            if(currentComboState == ComboState.PUNCH_2)
            {
                animator.SetTrigger("Punch2");
            }
            
            if(currentComboState == ComboState.PUNCH_3)
            {
                animator.SetTrigger("Punch3");
            }

        }

        starterAssetInputs.combat = false;
    }

    void ResetComboState()
    {
        if(activeTimerToReset)
        {
            currentComboTimer -=  Time.deltaTime;

            if(currentComboTimer <= 0.0f || (currentComboState == ComboState.PUNCH_3 && currentComboTimer <= 0.2f))
            {
                currentComboState = ComboState.NONE;
                activeTimerToReset = false;
                currentComboTimer = defaultComboTimer;
                
                thirdpersonController.SetMoveSpeed(normalMoveSpeed);
                thirdpersonController.SetSprintSpeed(normalSprintSpeed);
            }
        }
    }

}
