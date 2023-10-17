using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private GameObject[] hearts = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RemoveHeart();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            AddHeart();
        }
    }

    public void RemoveHeart()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i].activeInHierarchy)
            {
                hearts[i].SetActive(false);
                break;
            }
        }
    }

    public void AddHeart()
    {
        for(int i = hearts.Length - 1; i >= 0; i--)
        {
            if (!hearts[i].activeInHierarchy)
            {
                hearts[i].SetActive(true);
                break;
            }
        }
    }
}
