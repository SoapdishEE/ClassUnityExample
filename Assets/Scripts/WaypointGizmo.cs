using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGizmo : MonoBehaviour
{
    [SerializeField] private float mSize = 1;

    private Transform[] mWaypoints;

    private void OnDrawGizmosSelected()
    {
        mWaypoints = GetComponentsInChildren<Transform>();
        var last = mWaypoints[mWaypoints.Length - 1].position;

        for(int i = 1; i < mWaypoints.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(mWaypoints[i].position, mSize);
            Gizmos.DrawLine(last, mWaypoints[i].position);
            last = mWaypoints[i].position;
        }
    }
}
