using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    [SerializeField] private Bullet mBullet = null;
    [SerializeField] private Missile mMissile = null;
    [SerializeField] private Rocket mRocket = null;

    private List<Bullet> mBullets;
    private List<Missile> mMissiles;
    private List<Rocket> mRockets;

    private int mAmountOfWeapons = 20;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        mBullets = new List<Bullet>();
        mMissiles = new List<Missile>();
        mRockets = new List<Rocket>();

        for(int i = 0; i < mAmountOfWeapons; i++)
        {
            var bullet = Instantiate(mBullet, transform);
            bullet.gameObject.SetActive(false);
            mBullets.Add(bullet);

            var missile = Instantiate(mMissile, transform);
            missile.gameObject.SetActive(false);
            mMissiles.Add(missile);

            var rocket = Instantiate(mRocket, transform);
            rocket.gameObject.SetActive(false);
            mRockets.Add(rocket);
        }
    }

    public Bullet GetBullet()
    {
        for(int i = 0; i < mBullets.Count; i++)
        {
            if (!mBullets[i].gameObject.activeInHierarchy)
            {
                return mBullets[i];
            }
        }

        var bullet = Instantiate(mBullet, transform);
        bullet.gameObject.SetActive(false);
        mBullets.Add(bullet);

        return bullet;
    }

    public Missile GetMissile()
    {
        for(int i = 0; i < mMissiles.Count; i++)
        {
            if (!mMissiles[i].gameObject.activeInHierarchy) 
            { 
                return mMissiles[i];
            }
        }

        var missile = Instantiate(mMissile, transform);
        missile.gameObject.SetActive(false);
        mMissiles.Add(missile);

        return missile;
    }

    public Rocket GetRocket()
    {
        for(int i = 0; i < mRockets.Count; i++)
        {
            if (!mRockets[i].gameObject.activeInHierarchy)
            {
                return mRockets[i];
            }
        }

        var rocket = Instantiate(mRocket, transform);
        rocket.gameObject.SetActive(false);
        mRockets.Add(rocket);

        return rocket;
    }
}
