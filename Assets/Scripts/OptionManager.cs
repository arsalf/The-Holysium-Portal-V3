using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class OptionManager : MonoBehaviour
{
    public GameObject canvasOption;
    private StarterAssetsInputs starterAssetsInputs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("g")){
            starterAssetsInputs.cursorLocked = false;
            canvasOption.SetActive(true);
            Debug.Log("masuk");
        }    
    }

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }


}
