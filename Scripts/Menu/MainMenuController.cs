using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Level1");

        PlayerPrefs.SetInt ("playerCurLives", 5);

        
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
