using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDefinition : MonoBehaviour
{
    public Transform[] points;

    public IEnumerator<Transform> getPathEnumerator()
    {
      if(points == null || points.Length < 1)
        {
          Debug.Log("PathDefinition1");
          yield break;
        }

      int direction = 1;
      int i = 0;

      while(true)
      {
        yield return points[i];

        if(points.Length == 1)
          continue;

        if(i <= 0)
          direction = 1;
        else if(i >= points.Length - 1)
          direction = -1;

        i = i + direction;
      }
    }

    public void OnDrawGizmos()
    {
      if(points == null || points.Length < 2)
        {
          Debug.Log("PathDefinition2");
          return;
        }

      for( int i = 1; i < points.Length; i++)
      {
        Gizmos.DrawLine(points[i - 1].position, points[i].position);
      }
    }
}
