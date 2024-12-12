using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using Unity.VisualScripting;

public class TaskPatrol : Node
{
    private Transform mTransform;
    private Transform[] mWaypoints;

    private int currentWaypointIndex;

    private float waitTime = 1f; //in seconds
    private float waitCounter = 0f;
    private bool waiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        mTransform = transform;
        mWaypoints = waypoints;
    }

    public override NodeState Evaluate()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
                waiting = false;
        }
        else
        {
            Transform wp = mWaypoints[currentWaypointIndex];
            if (Vector3.Distance(mTransform.position, wp.position) < 1f)
            {
                mTransform.position = wp.position;
                waitCounter = 0f;
                waiting = true;

                currentWaypointIndex = (currentWaypointIndex + 1) % mWaypoints.Length;
            }
            else
            {
                mTransform.position = Vector3.MoveTowards(mTransform.position, wp.position, EnemyBT.speed * Time.deltaTime);
                mTransform.LookAt(wp.position);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
