using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeLevel : MonoBehaviour
{


    public GameObject regularBrickPrefab;
    public GameObject mediumBrickPrefab;
    public GameObject largeBrickPrefab;
    public GameObject bombBrickPrefab; 
    private float brickSpacingX = 0.3f;
    private float brickSpacingY = 0.5f; 
    private Vector2 maxBrickPositions = new Vector2(4f, 9f);
    private bool needToMakeLevel = true;
    private bool levelOneFinished = false;
    private bool levelInProgress = false;
    private int maxNumOfBombs = 2;
    private int maxNumOfBoms2 = 3;

    // Update is called once per frame

    private void Start()
    {
        // Setting up the transform for where the bricks should be placed
        transform.position = new Vector3(-5, 3, 1);

    }

    private void Update()
    {
        // Handles creation of first level
        if (needToMakeLevel && !levelOneFinished && !levelInProgress)
        {
            //readyPlayerFive();
            needToMakeLevel = false;
            levelInProgress = true; 
        }
    }

    // Function that creates the first level of the game
    public void readyPlayerOne()
    {
        
        int bombsCreated = 0; 
        for (int cols = 0; cols < maxBrickPositions.x; cols++)
        {
            for (int rows = 0; rows < maxBrickPositions.y; rows++)
            {

                float maybeNewBomb = Random.Range(-2.0f, 1.0f);
                if (maybeNewBomb > 0 && bombsCreated < maxNumOfBombs)
                {
                    GameObject newBombBrick = Instantiate(bombBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    float newBrickXPosition = rows * (bombBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (bombBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBombBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newBombBrick.transform.position = newBombBrickPosn + transform.position;
                    bombsCreated += 1;
                    maybeNewBomb = Random.Range(-4.0f, 1.0f);
                }

                else
                {
                    // Start out by initialzing the brick GameObject
                    GameObject newRegularBrick = Instantiate(regularBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    // Calculate where this brick should go
                    float newBrickXPosition = rows * (regularBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (regularBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBrickPosition = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    // Assign brick to its new position
                    newRegularBrick.transform.position = transform.position + newBrickPosition;
                }  
            }
        }
    }

    // Function that creates the second level of the game
    public void readyPlayerTwo()
    {
        int bombsIntiated = 0;
        for (int cols = 0; cols < maxBrickPositions.x; cols++)
        {
            
            for (int rows = 0; rows < maxBrickPositions.y; rows++)
            {

                float maybeNewBomb = Random.Range(-2.0f, 1.0f);
                if (maybeNewBomb > 0 && bombsIntiated < maxNumOfBombs)
                {
                    GameObject newBombBrick = Instantiate(bombBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    float newBrickXPosition = rows * (bombBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (bombBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBombBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newBombBrick.transform.position = newBombBrickPosn + transform.position;
                    bombsIntiated += 1;
                    maybeNewBomb = Random.Range(-3.0f, 1.0f); 
                }

                else if (cols % 2 == 0 && rows % 2 == 0)
                {
                    GameObject newMediumBrick = Instantiate(mediumBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    SpriteRenderer spriteRend = newMediumBrick.GetComponent<SpriteRenderer>(); 
                    float newBrickXPosition = rows * (mediumBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (mediumBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    spriteRend.sortingOrder = 1;
                    newMediumBrick.transform.position = newBrickPosn + transform.position; 
                }

                else
                {
                    GameObject newRegularBrick = Instantiate(regularBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    float newBrickXPosition = rows * (regularBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (regularBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBrickPosition = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newRegularBrick.transform.position = transform.position + newBrickPosition;
                }
            }
        }
    }

    // Function that creates the third level of the game
    public void readyPlayerThree()
    {
        int bombsMade = 0;
        for (int cols = 0; cols < maxBrickPositions.x; cols++)
        {
            for (int rows = 0; rows < maxBrickPositions.y; rows++)
            {
                float maybeNewBomb = Random.Range(-2.0f, 1.0f);
                if (maybeNewBomb > 0 && bombsMade < maxNumOfBombs)
                {
                    GameObject newBombBrick = Instantiate(bombBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    float newBrickXPosition = rows * (bombBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (bombBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBombBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newBombBrick.transform.position = newBombBrickPosn + transform.position;
                    bombsMade += 1;
                    maybeNewBomb = Random.Range(-3.0f, 1.0f);
                }
                else if (cols % 2 == 0 && rows % 2 == 0)
                {
                    GameObject newMediumBrick = Instantiate(mediumBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    SpriteRenderer spriteRend = newMediumBrick.GetComponent<SpriteRenderer>();
                    float newBrickXPosition = rows * (mediumBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (mediumBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    spriteRend.sortingOrder = 1;
                    newMediumBrick.transform.position = newBrickPosn + transform.position;
                }
                else if (cols % 3 == 0 && rows % 3 == 0)
                {
                    GameObject newHeavyBrick = Instantiate(largeBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    SpriteRenderer heavyBrickRenderer = newHeavyBrick.GetComponent<SpriteRenderer>();
                    float newBrickXPosition = rows * (largeBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (largeBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newHeavyBrick.transform.position = newBrickPosn + transform.position;
                    heavyBrickRenderer.sortingOrder = 1; 
                }
                else
                {
                    GameObject newRegularBrick = Instantiate(regularBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    float newBrickXPosition = rows * (regularBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (regularBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBrickPosition = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newRegularBrick.transform.position = transform.position + newBrickPosition;
                }
            }
        }
    }

    // Function the creates the fourth level of the game
    public void readyPlayerFour()
    {
        int bombsCreate = 0;
        for (int cols = 0; cols < maxBrickPositions.x; cols++)
        {
            for (int rows = 0; rows < maxBrickPositions.y; rows++)
            {
                float maybeNewBomb = Random.Range(-2.0f, 1.0f);
                if (maybeNewBomb > 0 && bombsCreate < maxNumOfBoms2)
                {
                    GameObject newBombBrick = Instantiate(bombBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    float newBrickXPosition = rows * (bombBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (bombBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBombBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newBombBrick.transform.position = newBombBrickPosn + transform.position;
                    bombsCreate += 1;
                    maybeNewBomb = Random.Range(-4.0f, 1.0f);
                }
                else if (cols % 2 == 0 && rows % 2 == 0)
                {
                    GameObject newHeavyBrick = Instantiate(largeBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    SpriteRenderer heavyBrickRenderer = newHeavyBrick.GetComponent<SpriteRenderer>();
                    float newBrickXPosition = rows * (largeBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (largeBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newHeavyBrick.transform.position = newBrickPosn + transform.position;
                    heavyBrickRenderer.sortingOrder = 1;
                }
                else
                {
                    GameObject newMediumBrick = Instantiate(mediumBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    SpriteRenderer spriteRend = newMediumBrick.GetComponent<SpriteRenderer>();
                    float newBrickXPosition = rows * (mediumBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (mediumBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    spriteRend.sortingOrder = 1;
                    newMediumBrick.transform.position = newBrickPosn + transform.position;
                }


            }
        }
    }

    public void readyPlayerFive()
    {
        int bombsCreated = 0;
        for (int cols = 0; cols < maxBrickPositions.x; cols ++)
        {
            for (int rows = 0; rows < maxBrickPositions.y; rows ++)
            {
                float maybeNewBomb = Random.Range(-2.0f, 1.0f);
                if (maybeNewBomb > 0 && bombsCreated < maxNumOfBoms2)
                {
                    GameObject newBombBrick = Instantiate(bombBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    float newBrickXPosition = rows * (bombBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (bombBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBombBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newBombBrick.transform.position = newBombBrickPosn + transform.position;
                    bombsCreated += 1;
                    maybeNewBomb = Random.Range(-4.0f, 1.0f);
                }
                else
                {
                    GameObject newHeavyBrick = Instantiate(largeBrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    SpriteRenderer heavyBrickRenderer = newHeavyBrick.GetComponent<SpriteRenderer>();
                    float newBrickXPosition = rows * (largeBrickPrefab.transform.localScale.x + brickSpacingX);
                    float newBrickYPosition = -cols * (largeBrickPrefab.transform.localScale.y + brickSpacingY);
                    Vector3 newBrickPosn = new Vector3(newBrickXPosition, newBrickYPosition, 1);
                    newHeavyBrick.transform.position = newBrickPosn + transform.position;
                    heavyBrickRenderer.sortingOrder = 1;
                }
            }
        }
    }

}
