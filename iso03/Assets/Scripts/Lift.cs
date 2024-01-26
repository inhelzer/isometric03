using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] Vector3 endPoint;
    [SerializeField] float speed;
    Vector3 moveVector;
    [SerializeField] bool isActive = false;
    [SerializeField] bool isLifting = false;

    // Start is called before the first frame update
    void Start()
    {
        moveVector = (endPoint - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if((isActive) && (FindObjectOfType<Movement>().isMoving == false))
        {
            isLifting = true;
            FindObjectOfType<Movement>().isLifting = true;
        }

        if(isLifting)
        {
            if (Vector3.Distance(transform.position, endPoint) >= 0.1f)
            {
                transform.position += moveVector * Time.deltaTime;
                moveVector = (endPoint - transform.position).normalized * speed;
            }
            else
            {
                transform.position = endPoint;
                isActive=false;
                isLifting=false;
                FindObjectOfType<Movement>().StopLifting(transform.position);

            }

            FindObjectOfType<Movement>().liftingPos = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isActive = true;
        }
    }
}
