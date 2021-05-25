using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logTrigger : MonoBehaviour
{

    public GameObject vil;
    public GameObject dialogueVil;
    DialogueTrigger dt;
    VillagerFollowPath vfp;
    ScoreManager scoreMan;
    PlayerBehaviors pb;
    public HungerBar_Script karmaBar;

    public bool called;
    // Start is called before the first frame update
    void Start()
    {
      vfp = vil.GetComponent<VillagerFollowPath>();
      dt = dialogueVil.GetComponent<DialogueTrigger>();
      scoreMan = FindObjectOfType<ScoreManager>();
      pb = GameObject.Find("Player").GetComponent<PlayerBehaviors>();

      called = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pushable")
        {
          Debug.Log("called");
          if(called == false)
          {
            if(vfp != null)
              vfp.startVillager();

            called = true;

            if(dt != null)
              {
                dt.questFulfilled = true;
              }

            if(dt != null && vfp != null)
              pb.changeKarma(10);
          }


          //Destroy(vil.GetComponent<VillagerFollowPath>());
        }
    }


}
