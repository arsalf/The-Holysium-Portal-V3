using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class OptionManager : MonoBehaviour
{
    public GameObject canvasOption;
    private StarterAssetsInputs starterAssetsInputs;
    // Start is called before the first frame update
    
    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenOption();
    }

    public void OpenOption()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){       
            Cursor.lockState = CursorLockMode.None;      
            Cursor.visible = true;      
            canvasOption.SetActive(true);            
        }   
    }

    public void CloseOption()
    {        
        Cursor.lockState = CursorLockMode.Locked;      
        Cursor.visible = false; 
        canvasOption.SetActive(false);
    }

}
