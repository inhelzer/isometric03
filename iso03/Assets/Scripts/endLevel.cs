using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{
    public bool isActive = false;
    public bool isPlaying = false;

    Animator anim;
    
    string currentAnimaton;
    const string idle = "idle";
    const string ending = "ending";
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((isActive) && (FindObjectOfType<Movement>().isMoving == false))
        {
            EndAnimation();
            FindObjectOfType<Movement>().isEnding = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;
    }

    public void EndAnimation()
    {
        anim.Play(ending);
    }

    
}
