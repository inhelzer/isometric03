using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using static UnityEditor.PlayerSettings;


public class PlayerController : MonoBehaviour
{
    
    public bool isHorizontal;
    public bool isVertical;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    GameObject currentPlayer;

    [SerializeField] Vector3 currentEndPos;
    string currentDirection;
    


    // Start is called before the first frame update
    void Start()
    {
        
        currentDirection = "Horizontal";
        currentPlayer = player1;
        FindObjectOfType<Movement>().ChangePos(player1.transform.position);

        player2.gameObject.SetActive(false);
        FindObjectOfType<followCamera>().ChangePlayer(currentPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPos(Vector3 pos, string direction)
    {
        currentEndPos = pos;
        if(currentDirection == direction)
        {
            FindObjectOfType<Movement>().ChangePos(pos);
        }
        else
        {

            if(currentDirection == "Horizontal")
            {
                toVertical();
            }
            else
            {
                toHorizontal();
            }
        }
        currentDirection = direction;
    }

    public void toVertical()
    {
        player2.gameObject.SetActive(true);
        currentPlayer = player2;
        
        
        player1.gameObject.SetActive(false);
        FindObjectOfType<followCamera>().ChangePlayer(currentPlayer);
        FindObjectOfType<Movement>().Jump(currentEndPos);
    }

    public void toHorizontal()
    {
        player1.gameObject.SetActive(true);
        currentPlayer = player1;
        
        player2.gameObject.SetActive(false);
        FindObjectOfType<followCamera>().ChangePlayer(currentPlayer);
        FindObjectOfType<Movement>().Jump(currentEndPos);
    }

    public void Hide()
    {
        player1.gameObject.SetActive(true);
        player1.GetComponent<SpriteRenderer>().enabled = false;
        player2.gameObject.SetActive(false);
        
    }
}
