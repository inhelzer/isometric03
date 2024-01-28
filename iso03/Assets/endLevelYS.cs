using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevelYS : MonoBehaviour
{
    public bool isActive = false;
    public bool isPlaying = false;

    Animator anim;

    string currentAnimaton;
    const string idle = "Ysidle";
    const string ending = "ensYS";
    float animTime;
    [SerializeField] float delay;


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
            isActive = false;
        }

        if ((isPlaying) && (Time.timeSinceLevelLoad - animTime >= delay))
        {

            FindObjectOfType<LevelLoader>().RandNextScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;
    }

    public void EndAnimation()
    {
        anim.Play(ending);
        isPlaying = true;
        animTime = Time.timeSinceLevelLoad;
    }
}
