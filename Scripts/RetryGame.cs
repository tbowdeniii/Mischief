using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    string previousLevel;


    public void LoadGame()
    {
        SceneManager.LoadScene("StartMenu");

    }

    public void RestartLevel()
    {
        previousLevel = PlayerPrefs.GetString("curLevel");
        SceneManager.LoadScene("Level1");

        PlayerPrefs.SetInt("playerCurLives", 5);

    }

    public void loadNewLevel()
    {
        // previousLevel = PlayerPrefs.GetString("curLevel");
        // if(previousLevel == "SECONDTutorialLevel")
        //   SceneManager.LoadScene("Level1");
        // if (previousLevel == "Level1")
        SceneManager.LoadScene("CastleLevel");
    }


}
