using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.Burst.Intrinsics;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderNew : MonoBehaviour
{
    static public int[] sceneNumbers = { 0, 1, 2, 3, 4 };
    static int counter = 0;
    int i1;
    int i2;
    int i1Prev;
    int i2Prev;
    int temp;

    // Start is called before the first frame update
    void Start()
    {
        SceneOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SceneOrder()
    {
        System.Random rnd = new System.Random();
        for (int j = 0; j < 6; j++)
        {
            
            i1 = rnd.Next(0, sceneNumbers.Length / 2);
            i2 = rnd.Next(sceneNumbers.Length / 2, sceneNumbers.Length);
            


            if ((i1 != i1Prev) || (i2 != i2Prev))
            {
                temp = sceneNumbers[i1];
                sceneNumbers[i1] = sceneNumbers[i2];
                sceneNumbers[i2] = temp;

                i1Prev = i1;
                i2Prev = i2;
            }

            
            
        }
        /*
        for (int col = 0; col < sceneNumbers.Length; col++)
        {
            Debug.Log(sceneNumbers[col]);
        }
        */
    }

    public void LoadNextScene()
    {
       
        counter++;
        

        if (counter >= sceneNumbers.Length)
        {
            Debug.Log("!!!");
            SceneOrder();
            counter = 0;
        }

        if(SceneManager.GetActiveScene().buildIndex != sceneNumbers[counter])
        {
            SceneManager.LoadScene(sceneNumbers[counter]);
            Debug.Log(counter);
        }
        else
        {
            SceneOrder();
        }

        




    }

   


}
