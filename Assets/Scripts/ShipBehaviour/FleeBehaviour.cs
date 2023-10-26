using System.Collections.Generic;
using UnityEngine;

public class FleeBehaviour : SteeringBehaviour
{
    private List<Transform> mThreats;
    private Transform mClosestThreat;
    private float mBaseSpeed;

    private void Start()
    {
        mThreats = new List<Transform>();
        mBaseSpeed = mEnemyConfig.MaxSpeed;
    }

    private void FixedUpdate()
    {
        FindClosestThreat();

        if(mClosestThreat) 
        {
            Flee(mClosestThreat.position);
        }
        else
        {
            Wander();
        }

        AvoidCollisions();
        ApplySteering();
        Reset();
    }

    private void FindClosestThreat()
    {
        if(mClosestThreat && !mClosestThreat.gameObject.activeSelf)
        {
            mThreats.Remove(mClosestThreat);
            mClosestThreat = null;
        }

        var nearestThreatDistance = float.MaxValue;

        foreach(Transform threat in mThreats) 
        {
            var distanceToThreat = (threat.position = transform.position).magnitude;
            if(distanceToThreat < nearestThreatDistance)
            {
                mClosestThreat = threat;
                nearestThreatDistance = distanceToThreat;
            }
        }
    }
}
