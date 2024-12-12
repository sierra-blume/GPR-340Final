using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform mTransform;

    public TaskGoToTarget(Transform transform)
    {
        mTransform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (Vector3.Distance(mTransform.position, target.position) > 1f)
        {
            mTransform.position = Vector3.MoveTowards(mTransform.position, target.position, EnemyBT.speed * Time.deltaTime);
            mTransform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
