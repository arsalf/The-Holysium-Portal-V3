using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AudioBG : MonoBehaviour
{
    public static AudioBG instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void MuteToggle(bool muted){
        if(muted){
            AudioListener.volume = 0;
        }else{
            AudioListener.volume = 1;
        }
    }
}