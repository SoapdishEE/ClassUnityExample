using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CapsuleCollider2D))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mRigidbody;
    [SerializeField] private WeaponData mWeaponConfig;

    public Rigidbody2D RocketRigidbody => mRigidbody;

    // Update is called once per frame
    private void FixedUpdate()
    {
        //apply forward acceleration
        mRigidbody.AddForce(mRigidbody.velocity * mWeaponConfig.Acceleration, ForceMode2D.Force);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mRigidbody.velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
