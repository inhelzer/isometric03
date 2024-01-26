using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 currentEndPos;
    [SerializeField] float moveSpeed;

    Vector3 moveVector = new Vector3 (0,0,0);
    [SerializeField] float xVector = 0.85f;
    [SerializeField] float yVector = 0.5f;

    [SerializeField] float minDis;
    [SerializeField] float dis;

    public bool isMoving = false;
    public bool isLifting = false;
    public Vector3 liftingPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(currentEndPos, transform.position);
        if (dis >= minDis)
        {
            transform.position += moveVector * moveSpeed * Time.deltaTime;
            isMoving = true;
        }
        else
        {
            transform.position = currentEndPos;
            isMoving = false;
        }

        if(isLifting)
        {
            transform.position = liftingPos;
        }

    }

    public void StopLifting(Vector3 pos)
    {
        transform.position = pos;
        isLifting = false;
        currentEndPos = transform.position;

    }

    

    public void ChangePos(Vector3 pos)
    {
        currentEndPos = pos;

        if(System.Math.Abs(pos.x - transform.position.x) <= 0.5f)
        {
            moveVector.x = 0;
            if(pos.y > transform.position.y)
            {
                moveVector.y = 1;
            }
            else
            {
                moveVector.y = -1;
            }
        }

        else
        {
            if (pos.x > transform.position.x)
            {
                moveVector.x = xVector;
            }
            if (pos.x < transform.position.x)
            {
                moveVector.x = -1 * xVector;
            }
            if (pos.y > transform.position.y)
            {
                moveVector.y = yVector;
            }
            if (pos.y < transform.position.y)
            {
                moveVector.y = -1 * yVector;
            }
        }

    }

    public void Jump(Vector3 pos)
    {
        currentEndPos = pos;
        transform.position = currentEndPos;
        
    }

   

}
