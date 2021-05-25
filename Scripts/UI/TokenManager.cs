using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenManager : MonoBehaviour
{

    private int tokenCount;



    private Text t;

    private MainQuestManager m;
    // Start is called before the first frame update
    void Start()
    {
      t = GetComponent<Text>();

      GameObject player = GameObject.Find("Player");
      m = player.GetComponent<MainQuestManager>();
      tokenCount = m.level1Q;
    }

    // Update is called once per frame
    void Update()
    {
      tokenCount = m.level1Q;
      t.text = "x " + tokenCount;

    }

    public void updateToken()
    {
      tokenCount++;
    }
}
