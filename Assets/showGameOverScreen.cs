using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class showGameOverScreen : MonoBehaviour
{
    public void showThisScreen()
    {
        this.gameObject.SetActive(true);

    }
    public void giveItAnotherTree()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
