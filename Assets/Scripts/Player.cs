using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;
    private float speed;

    //public int Health => health;

    //public int health { get; private set; }

    public void SetHealth(int _health) { health = _health; }
    public int GetHealth() { return health; } 

    private void Start()
    {
        health = 100;
        speed = 50;
    }
}
