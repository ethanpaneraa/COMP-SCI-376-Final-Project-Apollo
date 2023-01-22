using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyHealthBrick : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 2;
    private SpriteRenderer heavyHealthBrickRenderer;
    private ball BallGameObject; 


    void Start()
    {
        heavyHealthBrickRenderer = GetComponent<SpriteRenderer>();
        BallGameObject = FindObjectOfType<ball>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "ball")
        {
            UpdateHealth();  
        }
    }

    // Handles all of the state changes for this Brick
    public void UpdateHealth()
    {
        health -= 1; 
        if (health < 0)
        {
            BallGameObject.bricksDestoryed += 1;
            BallGameObject.needToUpdateScore = true;
            Destroy(this.gameObject); 
        }
        else if (health == 1)
        {
            heavyHealthBrickRenderer.color = Color.yellow; 
        }

        else if (health == 0)
        {
            heavyHealthBrickRenderer.color = Color.red; 
        }
    }
}
