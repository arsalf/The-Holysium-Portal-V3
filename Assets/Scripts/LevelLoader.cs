using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animatorTransition;
    public float transitionTime = 1f;

    public void LoadNextScene(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
    }

    IEnumerator LoadLevel(string levelName)
    {
        animatorTransition.SetTrigger("Fade");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }
}
