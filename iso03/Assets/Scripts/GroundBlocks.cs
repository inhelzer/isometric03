using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlocks : MonoBehaviour
{
    [SerializeField] Vector3 clickPos;
    string direction;
    [SerializeField] bool isHorizontal;
    [SerializeField] bool isVertival;

    private void Start()
    {
        if(isHorizontal)
        {
            direction = "Horizontal";
        }
        if (isVertival)
        {
            direction = "Vertival";
        }
    }

    private void OnMouseDown()
    {
        clickPos = transform.position;
        FindObjectOfType<PlayerController>().NextPos(clickPos, direction);
    }
}
