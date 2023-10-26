using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private float mSpeed = 5;
    [SerializeField] private float mDistanceToNextWaypoint = 1;
    [SerializeField] private Transform mWaypoint = null;

    private Transform[] mWaypoints;
    private int mCurrentWaypoint;

    private void Start()
    {
        var temp = mWaypoint.GetComponentsInChildren<Transform>();
        mWaypoints = new Transform[temp.Length - 1];

        for(int i  = 1; i < temp.Length; i++)
        {
            mWaypoints[i - 1] = temp[i];
        }

        mCurrentWaypoint = 0;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, mWaypoints[mCurrentWaypoint].position, mSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, mWaypoints[mCurrentWaypoint].position) < mDistanceToNextWaypoint)
        {
            mCurrentWaypoint++;

            if (mCurrentWaypoint >= mWaypoints.Length) { mCurrentWaypoint = 0; }
        }
    }
}
