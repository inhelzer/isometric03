using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int nextScene;

    private void Start()
    {
      
        
        

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        
        if(nextScene != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            RandNextScene();
        }
    }

    public void RandNextScene()
    {
        nextScene = Random.Range(0, 4);
        LoadNextScene();
    }



    
}
