using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{

    private int lifeCount;

    private Text t;

    public PlayerController player;

    public string mainMenu;

    // Start is called before the first frame update
    void Start()
    {
      t = GetComponent<Text>();


      lifeCount = PlayerPrefs.GetInt("playerCurLives");


      player = FindObjectOfType<PlayerController>();

      t.text = "x " + lifeCount;

      if(lifeCount == 0)
      {
        SceneManager.LoadScene("GameOver");
      }
    }



    public void lifeChange(int num)
    {
      //Update playerCurLives
      PlayerPrefs.SetInt("playerCurLives", PlayerPrefs.GetInt("playerCurLives") + num);
      //Retrieve updated playerCurLives

    }
}
