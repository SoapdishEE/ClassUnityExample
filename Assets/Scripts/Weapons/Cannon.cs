using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mRigidbody = null;
    [SerializeField] private WeaponData mWeaponConfig = null;
    private List<Transform> mTargets;
    private bool mIsShooting;

    // Start is called before the first frame update
    void Start()
    {
        mTargets = new List<Transform>();
        mIsShooting = false;
    }

    private void OnDisable()
    {
        mTargets.Clear();
        mIsShooting = false;
        CancelInvoke();
    }

    public void FireWeapon()
    {
        if(mTargets.Count > 0)
        {
            var bullet = WeaponManager.Instance.GetBullet();
            var shipVelocity = (Vector3)mRigidbody.velocity;
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.gameObject.SetActive(true);
            bullet.BulletRigidbody.velocity = shipVelocity + ((mTargets[0].position - transform.position).normalized *
                mWeaponConfig.Speed);
        }
        else
        {
            if (mIsShooting)
            {
                CancelInvoke();
                mIsShooting = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mTargets.Add(collision.transform);

        if (!mIsShooting)
        {
            InvokeRepeating("FireWeapon", mWeaponConfig.RateOfFire, mWeaponConfig.RateOfFire);
            mIsShooting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        mTargets.Remove(collision.transform);
    }
}
