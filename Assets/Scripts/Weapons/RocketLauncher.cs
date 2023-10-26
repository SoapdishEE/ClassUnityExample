using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private WeaponData mWeaponConfig = null;
    private List<Transform> mTargets;
    private bool mIsShooting;

    private void Start()
    {
        mTargets = new List<Transform>();
        mIsShooting = false;
    }

    private void OnDisable()
    {
        CancelInvoke();
        mIsShooting = false;
    }

    public void FireWeapon()
    {
        if(mTargets.Count > 0)
        {
            var rocket = WeaponManager.Instance.GetRocket();
            rocket.transform.position = transform.position;
            rocket.transform.rotation = transform.rotation;
            rocket.gameObject.SetActive(true);
            rocket.RocketRigidbody.AddForce((mTargets[0].position - transform.position).normalized * mWeaponConfig.Acceleration,
                ForceMode2D.Force);
        }
        else
        {
            CancelInvoke();
            mIsShooting = false;
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
