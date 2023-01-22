using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeathSoundPlayer : MonoBehaviour
{

    public ball ballGameObject;
    private AudioSource BallDeathSound;
    // Start is called before the first frame update
    void Start()
    {
        ballGameObject = FindObjectOfType<ball>();
        BallDeathSound = GetComponent<AudioSource>(); 
    }

    private void Update()
    {
        if (ballGameObject.ballOOB)
        {
            BallDeathSound.Play();
            ballGameObject.ballOOB = false; 
        }
    }



}
