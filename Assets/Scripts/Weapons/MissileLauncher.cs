using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
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
            var missile = WeaponManager.Instance.GetMissile();
            missile.SetTarget(mTargets[0]);

            missile.transform.position = transform.position;
            missile.transform.rotation = transform.rotation;
            missile.gameObject.SetActive(true);
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
