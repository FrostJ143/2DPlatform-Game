using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private GameObject[] wayPointArray;
    
    private int targetWayPointIndex = 0;

    // Update is called once per frame
    
    void Update()
    {
        Vector3 currentPosition = wayPointArray[targetWayPointIndex].transform.position;
        float distance = Vector2.Distance(transform.position, currentPosition);
        if (distance < .1f)
        {
            targetWayPointIndex++;
            if (targetWayPointIndex >= wayPointArray.Length)
            {
                targetWayPointIndex = 0;
            }
            currentPosition = wayPointArray[targetWayPointIndex].transform.position;
        }
        
        
        transform.position = Vector2.MoveTowards(transform.position, currentPosition, movingSpeed * Time.deltaTime);
    }
}
