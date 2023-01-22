using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBrick : MonoBehaviour
{


    public float exposionRadius;
    public ball ballGameObject;

    private void Start()
    {
        exposionRadius = 1.5f;
        ballGameObject = FindObjectOfType<ball>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "ball")
        {
            goBoom();
            Destroy(this.gameObject); 
        }
    }
    // function for handling everything for the bomb
    public void goBoom()
    {
        // Get all of the objects that are within our blast radius
        Collider2D[] allBricksinArea = Physics2D.OverlapCircleAll(transform.position, exposionRadius);
        foreach (Collider2D brickGO in allBricksinArea)
        {
            // We're getting these components so we know what we need to destory/update/leave alone
            heavyHealthBrick heavyBrick = brickGO.GetComponent<heavyHealthBrick>();
            mediumHealthBrick medBrick = brickGO.GetComponent<mediumHealthBrick>();
            ball ballGameObj = brickGO.GetComponent<ball>();
            player paddleGameObj = brickGO.GetComponent<player>(); 
            if (heavyBrick != null)
            {
                heavyBrick.UpdateHealth();
            }
            else if (medBrick != null)
            {
                medBrick.UpdateHealth();
            }
            else if (ballGameObj != null)
            {
                continue;
            }
            else if (paddleGameObj != null)
            {
                continue;
            }
            else
            {
                ballGameObject.bricksDestoryed += 1; 
                Destroy(brickGO.gameObject);
            }
        }
    }
}
