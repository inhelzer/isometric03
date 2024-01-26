using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    GameObject playerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, -10);
    }

    

    public void ChangePlayer (GameObject player)
    {
        playerObject = player;
    }
}
