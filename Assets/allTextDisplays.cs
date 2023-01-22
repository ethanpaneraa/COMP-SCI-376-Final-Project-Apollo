using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class allTextDisplays : MonoBehaviour
{

    public Text scoreText;
    public Text LivesText;
    public Text BallVelocity;
    public Text amountOfBricksLeft;
    public Text amountOfLevelsFinished; 
    private player playerGameObject;
    private ball BallGameObject;
    private Rigidbody2D BallRB;
    public int startingScore = 0; 
    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = FindObjectOfType<player>();
        BallGameObject = FindObjectOfType<ball>();
        BallRB = BallGameObject.GetComponent<Rigidbody2D>(); 
    }

    //Update is called once per frame
    void Update()
    {
        if (BallGameObject.needToUpdateScore)
        {
            startingScore += BallGameObject.scoreUpdateValue;
            scoreText.text = $"Score: {startingScore}";
            BallGameObject.needToUpdateScore = false;
        }

        if (BallGameObject.ballOOB)
        {
            startingScore -= 100;
            scoreText.text = $"Score: {startingScore}";
        }

        LivesText.text = $"Lives: {playerGameObject.playerlives}";
        BallVelocity.text = $"Ball Velocity: {BallRB.velocity.magnitude}";
        amountOfBricksLeft.text = $"Bricks Left: {36 - BallGameObject.bricksDestoryed}/36";
        amountOfLevelsFinished.text = $"Levels Completed: {playerGameObject.totalAmountofLevelsFinished}/5"; 
    }
}
