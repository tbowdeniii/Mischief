using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerFollowPath : MonoBehaviour
{

    public VillagerPathDefinition path;
    public float speed = 1.0f;
    public float maxDistanceToGoal = .01f;

    private IEnumerator<Transform> curPoint;
    bool moving;


    public void startVillager()
    {
      StartCoroutine(moveVillager());
    }
    public IEnumerator moveVillager()
    {
      if(path == null)
      {
        Debug.Log("followPath1");
        yield break;
      }

      curPoint = path.getPathEnumerator();
      curPoint.MoveNext();

      if(curPoint.Current == null)
        {
          Debug.Log("followPath2");
          yield break;
        }
      transform.position = curPoint.Current.position;

        for(int i = 0; i < 1000; i++){

          if(curPoint == null || curPoint.Current == null)
            yield break;
          //Debug.Log(curPoint.Current);
          transform.position = Vector3.MoveTowards(transform.position, curPoint.Current.position, Time.deltaTime * speed);

          var distanceSquared = (transform.position - curPoint.Current.position).sqrMagnitude;
          if(distanceSquared < maxDistanceToGoal * maxDistanceToGoal)
            curPoint.MoveNext();
          yield return new WaitForEndOfFrame();
        }




  }


}
