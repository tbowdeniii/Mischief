using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{

    Animator animator;
    string previousLevel;
    int score;
    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            animator.SetTrigger("PlayerTouch");
            score = PlayerPrefs.GetInt("playerCurScore");
            StartCoroutine(levelChange());
        }
    }

    IEnumerator levelChange()
    {
        yield return new WaitForSeconds(2);
        previousLevel = PlayerPrefs.GetString("curLevel");
        if(previousLevel == "Level1" && score >= 60)
          SceneManager.LoadScene("WinLevel");
        if(previousLevel == "Level1" && score < 60)
          SceneManager.LoadScene("LoseLevel1");
        if(previousLevel == "CastleLevel")
          SceneManager.LoadScene("WinEntireGame");
    }
}
