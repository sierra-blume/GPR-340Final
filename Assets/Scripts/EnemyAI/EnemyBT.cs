using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class EnemyBT : BehaviorTree.Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 50f;
    public static float fovRange = 40f;

    protected override Node SetupTree()
    {
        Node root = new TaskPatrol(transform, waypoints);

        /*Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOV(transform),
                new TaskGoToTarget(transform)
            }),
            new TaskPatrol(transform, waypoints),
        });*/

        return root;
    }
}