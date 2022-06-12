using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class ThirdPersonAimController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private Canvas canvasCrosshair;
    [SerializeField] private LayerMask aimColliderLayerMask;    
    [SerializeField] private float normalSensitivity = 1f;
    [SerializeField] private float aimSensitivity = .5f;
    [SerializeField] private Transform pfBulletProjectil;
    [SerializeField] private Transform spawnBulletPosisiton;
    [SerializeField] private Transform TargetAimPosition;
    
    
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdpersonController;
    private Animator animator;
 
    private void Awake()
    {
        animator = GetComponent<Animator>();
        thirdpersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {            
            mouseWorldPosition = raycastHit.point;
            TargetAimPosition.position = raycastHit.point;
        }

        if(starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            canvasCrosshair.gameObject.SetActive(true);
            
            thirdpersonController.SetSensitivity(aimSensitivity);
            thirdpersonController.SetRotateOnMove(false);
            
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;            
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);                        

            if(starterAssetsInputs.shoot)
            {
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosisiton.position).normalized;
                Instantiate(pfBulletProjectil, spawnBulletPosisiton.position, Quaternion.LookRotation(aimDir, Vector3.up));                
            }            
        } else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            canvasCrosshair.gameObject.SetActive(false);
            thirdpersonController.SetSensitivity(normalSensitivity);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            thirdpersonController.SetRotateOnMove(true);            
        }    
        starterAssetsInputs.shoot = false;

    }
}
