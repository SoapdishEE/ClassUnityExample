using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject coin = null;
    [SerializeField] private Transform[] coinSpawns = null;

    private float timer;
    private const float RESET_TIME = 3;

    private void Start()
    {
        timer = RESET_TIME;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            Instantiate(coin, coinSpawns[Random.Range(0, coinSpawns.Length)].position, coinSpawns[0].rotation);
            timer = RESET_TIME;
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(coin, transform.position, transform.rotation);
        }*/
    }
}
