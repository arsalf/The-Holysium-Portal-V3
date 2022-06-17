using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image muteOn;
    [SerializeField] Image muteOff;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted")){
            PlayerPrefs.SetInt("muted",0);
            Load();
        }else{
            Load();
        }   

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void onButtonPress(){
        if(muted == false){
            muted = true;
            AudioListener.pause = true;
        }else{
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    public void UpdateButtonIcon(){
        if(muted == false){
            muteOn.enabled = false;
            muteOff.enabled = true;
        }else{
            muteOn.enabled = true;
            muteOff.enabled = false;
        }
    }


    private void Load(){
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save(){
        PlayerPrefs.SetInt("muted",muted?1:0);
    }
}
