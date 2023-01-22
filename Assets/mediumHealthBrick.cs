using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mediumHealthBrick : MonoBehaviour
{
    public int health = 1;
    private SpriteRenderer mediumBrickHealthBrickRenderer;
    private ball BallGameObject; 
    // Start is called before the first frame update


    private void Start()
    {
        mediumBrickHealthBrickRenderer = GetComponent<SpriteRenderer>();
        BallGameObject = FindObjectOfType<ball>(); 
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "ball")
        {
            UpdateHealth(); 
        }
    }

    // Handles all of the different brick states for us
    public void UpdateHealth()
    {
        health -= 1;

        if (health < 0)
        {
            BallGameObject.bricksDestoryed += 1;
            BallGameObject.needToUpdateScore = true; 
            Destroy(this.gameObject); 
        }
        if (health == 0)
        {
            mediumBrickHealthBrickRenderer.color = Color.red; 
        }
    }


}
