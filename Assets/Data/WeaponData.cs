using UnityEngine;


[CreateAssetMenu(fileName = "WeaponConfig_", menuName = "ScriptableObject/WeaponConfig", order = 3)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private float mSpeed = 0;
    [SerializeField] private float mRateOfFire = 0;
    [SerializeField, Min(0)] private float mShotDelay = 0;
    [SerializeField] private float mAcceleration = 0;
    [SerializeField] private float mTurningSpeed = 0;

    public float Speed => mSpeed;
    public float RateOfFire => mRateOfFire;
    public float Acceleration => mAcceleration;
    public float ShotDelay => mShotDelay;
    public float TurningSpeed => mTurningSpeed;
}
