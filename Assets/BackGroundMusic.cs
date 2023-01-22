using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{

    private player playerGameObject;
    private AudioSource audioSourceOject;
    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = FindObjectOfType<player>();
        audioSourceOject = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerGameObject.playerlives == 0)
        {
            audioSourceOject.Stop(); 
        }
    }
}
