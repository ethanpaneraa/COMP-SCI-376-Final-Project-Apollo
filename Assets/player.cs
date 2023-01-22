using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    private Rigidbody2D playerRigidBody;
    public makeLevel LevelGenerator;
    public ball BallGameObject;
    public showGameOverScreen gameOverScreen;
    public pauseScreen pauseScreen;
    public startScreen startScreen; 
    private float paddleSpeed = 47.0f;
    private float leftHandBoundary = -7.8f;
    private float righthandBoundary = 7.8f;
    public bool GameLive = false;
    public int playerlives = 5;
    private bool playerAbleToMove = false;
    private bool levelOneComplete = false;
    private bool levelTwoComplete = false;
    private bool levelThreeComplete = false;
    private bool levelFourComplete = false; 
    private bool levelFiveComplete = false;
    private bool neeedToMakeLevel = true;
    private bool pauseScreenActive = false;
    private bool startScreenActive = false;
    private bool needToUpdateLevels = false; 
    public int totalAmountofLevelsFinished = 0;
    private bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        LevelGenerator = FindObjectOfType<makeLevel>();
        BallGameObject = FindObjectOfType<ball>();
    }

    private void Update()
    {
        if (playerlives == 0)
        {
            playerAbleToMove = false;
            BallGameObject.spaceKeyEnabled = false; 
            gameOverScreen.showThisScreen(); 
        }
        if (neeedToMakeLevel && !levelOneComplete)
        {
            LevelGenerator.readyPlayerOne();
            neeedToMakeLevel = false; 
        }
        if (BallGameObject.bricksDestoryed == 36 && !levelOneComplete)
        {
            totalAmountofLevelsFinished += 1;
            BallGameObject.bricksDestoryed = 0;
            BallGameObject.spaceKeyEnabled = true; 
            levelOneComplete = true;
            neeedToMakeLevel = true;
            GameLive = false;  
        }
        if (neeedToMakeLevel && !levelTwoComplete)
        {
            LevelGenerator.readyPlayerTwo();
            neeedToMakeLevel = false;
            playerlives += 5;
        }
        if (BallGameObject.bricksDestoryed == 36 && !levelTwoComplete)
        {
            totalAmountofLevelsFinished += 1;
            BallGameObject.bricksDestoryed = 0;
            BallGameObject.spaceKeyEnabled = true;
            levelTwoComplete = true;
            neeedToMakeLevel = true;
            GameLive = false;
        }
        if (neeedToMakeLevel && !levelThreeComplete)
        {
            LevelGenerator.readyPlayerThree();
            neeedToMakeLevel = false;
            playerlives += 5;
        }
        if (BallGameObject.bricksDestoryed == 36 && !levelThreeComplete)
        {
            totalAmountofLevelsFinished += 1;
            BallGameObject.bricksDestoryed = 0;
            BallGameObject.spaceKeyEnabled = true;
            levelThreeComplete = true;
            neeedToMakeLevel = true;
            GameLive = true; 
        }
        if (neeedToMakeLevel && !levelFourComplete)
        {
            LevelGenerator.readyPlayerFour();
            neeedToMakeLevel = false;
            playerlives += 5;
        }
        if (BallGameObject.bricksDestoryed == 36 && !levelFourComplete)
        {
            totalAmountofLevelsFinished += 1;
            BallGameObject.bricksDestoryed = 0;
            BallGameObject.spaceKeyEnabled = true;
            levelFourComplete = true;
            neeedToMakeLevel = true;
            GameLive = false; 
        }
        if (neeedToMakeLevel && !levelFiveComplete)
        {
            LevelGenerator.readyPlayerFive();
            neeedToMakeLevel = false;
            playerlives += 5;
        

        }

        if (BallGameObject.bricksDestoryed == 36 && !levelFiveComplete && !gameOver)
        {
            needToUpdateLevels = true; 
            playerAbleToMove = false;
            BallGameObject.spaceKeyEnabled = false; 
            gameOverScreen.showThisScreen();
        }

        if (needToUpdateLevels)
        {
            totalAmountofLevelsFinished += 1;
            needToUpdateLevels = false;
            gameOver = true; 
        }

        if (Input.GetKeyDown(KeyCode.Escape) && playerAbleToMove)
        {
            playerAbleToMove = false;
            GameLive = false; 
            BallGameObject.spaceKeyEnabled = false;
            pauseScreenActive = true; 
            pauseScreen.PauseScreen(); 

        }

        if (pauseScreenActive)
        {
            BallGameObject.spaceKeyEnabled = false;
            playerAbleToMove = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && pauseScreenActive)
        {
            playerAbleToMove = true;
            pauseScreenActive = false;
            BallGameObject.spaceKeyEnabled = true;
            pauseScreen.UnPauseScreen();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerAbleToMove = true;
            BallGameObject.spaceKeyEnabled = true;
            startScreenActive = false; 
            startScreen.StartGame(); 
        }


        // This is simply for the peer reviewers
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !pauseScreenActive && !startScreenActive)
        {
            BallGameObject.bricksDestoryed = 36;
        }
        // This is simply for the peer reviewers
        if (Input.GetKey(KeyCode.RightArrow) && !pauseScreenActive && !startScreenActive)
        {
            BallGameObject.bricksDestoryed = 0; 
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        // Player movement
        if (playerAbleToMove)
        {
            if (Input.GetKey(KeyCode.A) && transform.position.x >= leftHandBoundary)
            {
                Vector2 leftDirection = Vector2.left;
                playerRigidBody.AddForce(paddleSpeed * leftDirection);
            }
            else if (Input.GetKey(KeyCode.D) && transform.position.x <= righthandBoundary)
            {
                Vector2 rightDirection = Vector2.right;
                playerRigidBody.AddForce(paddleSpeed * rightDirection);
            }
            else
            {
                playerRigidBody.velocity = Vector3.zero;
            }
        }
    }

}
