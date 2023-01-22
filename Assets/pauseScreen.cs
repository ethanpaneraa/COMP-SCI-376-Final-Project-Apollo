using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseScreen : MonoBehaviour
{
    public void PauseScreen()
    {
        this.gameObject.SetActive(true);
    }

    public void UnPauseScreen()
    {
        this.gameObject.SetActive(false); 
    }

}
