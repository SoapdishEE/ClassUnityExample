using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig_", menuName = "ScriptableObject/EnemyConfig", order = 2)]
public class EnemyShipData : ScriptableObject
{
    [SerializeField] private float mMaxSpeed = 0;
    [SerializeField] private float mTurnSpeed = 0;
    [SerializeField] private float mWanderCircleDistance = 0;
    [SerializeField] private float mWanderCircleRadius = 0;
    [SerializeField] private float mWanderAngleAdjustment = 0;
    [SerializeField] private float mAvoidDistance = 0;
    [SerializeField] private LayerMask mAvoidThese;
    [SerializeField] private float mSlowingRadius = 0;

    public float MaxSpeed => mMaxSpeed;
    public float TurnSpeed => mTurnSpeed;
    public float WanderCircleDistance => mWanderCircleDistance;
    public float WanderCircleRadius => mWanderCircleRadius;
    public float WanderAngleAdjustment => mWanderAngleAdjustment;
    public float AvoidDistance => mAvoidDistance;
    public LayerMask AvoidThese => mAvoidThese;
    public float SlowingRadius => mSlowingRadius;
}
