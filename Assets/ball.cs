using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{


    public player playerGameObject; 
    private Rigidbody2D ballRidgidBody;
    private float ballSpeed = 575.0f;
    private float testSpeed = 10.0f;
    public bool spaceKeyEnabled = false;
    private AudioSource ballBounceSound;
    public bool ballOOB = false;
    public int bricksDestoryed = 0;
    public int scoreUpdateValue = 25; 
    public bool needToUpdateScore = false; 

    // Start is called before the first frame update
    void Start()
    {
        ballRidgidBody = GetComponent<Rigidbody2D>();
        ballBounceSound = GetComponent<AudioSource>();
        playerGameObject = FindObjectOfType<player>();

    }

    // Update is called once per frame
    void Update()
    {
        // Getting the ball to follow the player in the beginning
        if (playerGameObject.GameLive == false)
        {
            resetBall(); 
        }
        if (playerGameObject.playerlives == 0)
        {
            this.gameObject.SetActive(false);
            ballRidgidBody.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        // Handles when the player starts the game
        if (Input.GetKey(KeyCode.Space) && spaceKeyEnabled)
        {
            // Need to prevent pressing SpaceBar because it could add force countiously
            spaceKeyEnabled = false;
            Vector2 upDirection = Vector2.up;
            ballRidgidBody.AddForce(ballSpeed * Random.insideUnitCircle.normalized);
            playerGameObject.GameLive = true;
        }
    }

    // Handles ball collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Chaning the velocity so that the ball goes in a random direction
        if (collision.collider.tag == "paddle")
        {
            ballRidgidBody.velocity = Random.insideUnitCircle.normalized * testSpeed;
            ballBounceSound.Play();
        }
        if (collision.collider.tag == "border")
        {
            ballRidgidBody.velocity = Random.insideUnitCircle.normalized * testSpeed;
            ballBounceSound.Play();
        }
        if (collision.collider.tag == "lowerBorder")
        {
            ballRidgidBody.velocity = Vector2.zero; 
            playerGameObject.playerlives -= 1;
            playerGameObject.GameLive = false;
            spaceKeyEnabled = true;
            ballOOB = true; 
            resetBall();
        }
        if (collision.collider.name == "regularBrick(Clone)")
        {
            Destroy(collision.collider.gameObject);
            needToUpdateScore = true; 
            ballBounceSound.Play();
            bricksDestoryed += 1;
        }
        if (collision.collider.name == "mediumHealthBrick(Clone)")
        {
            ballBounceSound.Play();
        }
        if (collision.collider.name == "heavyHealthBrick(Clone)")
        {
            ballBounceSound.Play();
        }
    }

    public void resetBall()
    {
        float playerXvalue = playerGameObject.transform.position.x;
        Vector3 newBallPosition = new Vector3(playerXvalue, -3.65f, 0);
        transform.position = newBallPosition;
    }
}
