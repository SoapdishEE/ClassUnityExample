using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private WeaponData mWeaponConfig = null;
    [SerializeField] private Rigidbody2D mRigidbody = null;

    private Transform mTarget;

    private void FixedUpdate()
    {
        if (mTarget)
        {
            var desiredVelocity = (mTarget.position - transform.position).normalized * mWeaponConfig.Speed;
            Vector3 currentVelocity = mRigidbody.velocity;
            var steering = desiredVelocity - currentVelocity;
            steering = steering.normalized * mWeaponConfig.TurningSpeed;
            mRigidbody.AddForce(steering, ForceMode2D.Force);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mRigidbody.velocity);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    public void SetTarget(Transform target) { mTarget = target; }
}
