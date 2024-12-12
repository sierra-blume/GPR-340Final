using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex;
    private float speed = 50f;

    private float waitTime = 1f; //in seconds
    private float waitCounter = 0f;
    private bool waiting = false;

    private void Update()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter < waitTime)
                return;
            waiting = false;
        }

        Transform wp = waypoints[currentWaypointIndex];
        if(Vector3.Distance(transform.position, wp.position) < 1f)
        {
            transform.position = wp.position;
            waitCounter = 0f;
            waiting = true;

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
            transform.LookAt(wp.position);
        }
    }
}
