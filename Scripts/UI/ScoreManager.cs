using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

  private int scoreCount;

  private Text t;

  //public PlayerController player;

  private int scoreVal;
  string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
      t = GetComponent<Text>();
      PlayerPrefs.SetString("curScreen", SceneManager.GetActiveScene().name);
      scoreCount = PlayerPrefs.GetInt("playerCurScore");
      currentLevel = PlayerPrefs.GetString("curScreen");

      if(scoreCount != 0 && currentLevel == "Level1")
      {
        scoreCount = 0;
        PlayerPrefs.SetInt("playercurScore", 0);
      }

      if(scoreCount != 0 && currentLevel == "WinLevel")
      {
        scoreCount = PlayerPrefs.GetInt("playerCurScore");

      }
      //player = FindObjectOfType<PlayerController>();

      t.text = "Score: " + scoreCount;
    }


    public void updateScore(int scoreVal)
    {
      scoreCount += scoreVal;
      PlayerPrefs.SetInt("playerCurScore", scoreCount);

      t.text = "Score: " + scoreCount;
    }
}
