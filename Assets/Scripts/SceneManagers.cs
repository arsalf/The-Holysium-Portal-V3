using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadScene(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        while(!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
        
    }
}
