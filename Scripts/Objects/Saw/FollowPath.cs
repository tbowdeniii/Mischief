using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public PathDefinition path;
    public float speed = 1.0f;
    public float maxDistanceToGoal = .1f;

    private IEnumerator<Transform> curPoint;

    void Start()
    {
        if(path == null)
        {
          Debug.Log("followPath1");
          return;
        }

        curPoint = path.getPathEnumerator();
        curPoint.MoveNext();

        if(curPoint.Current == null)
          {
            Debug.Log("followPath2");
            return;
          }
        transform.position = curPoint.Current.position;
    }

    void Update()
    {
        if(curPoint == null || curPoint.Current == null)
          {
            Debug.Log("followPath3");
            return;
          }

        transform.position = Vector3.MoveTowards(transform.position, curPoint.Current.position, Time.deltaTime * speed);

        var distanceSquared = (transform.position - curPoint.Current.position).sqrMagnitude;
        if(distanceSquared < maxDistanceToGoal * maxDistanceToGoal)
        curPoint.MoveNext();
    }
}
