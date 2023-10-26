using UnityEngine;

public class SeekBehaviour : SteeringBehaviour
{
    [SerializeField] private Transform mTarget = null;

    private void FixedUpdate()
    {
        Seek(mTarget.position, mEnemyConfig.SlowingRadius);
        ApplySteering();
        AvoidCollisions();
        Reset();
    }
}
