using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public enum Players { PlayerOne, PlayerTwo, PlayerThree}

    [SerializeField] private Players players = Players.PlayerOne;

    [SerializeField] private Transform trans = null;
    [SerializeField] private MeshRenderer meshRenderer = null;

    [SerializeField] private int[] numbers;
    [SerializeField] private List<int> numbersTwo;

    [SerializeField] private Player player = null;
    [SerializeField] private GameObject enemy = null;

    [SerializeField] private Vector3 pos;

    private int testNumber = 10;

    private void Awake()
    {
        switch (players)
        {
            case Players.PlayerOne:

                break;
        }
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    // Start is called before the first frame update
    private void Start()
    {
        numbers[(int)players] = 100;

        if(player != null)
        {
            player.SetHealth(0);
            //player.health = 0;

            if(player.GetHealth() <= 0)
            {
                player.gameObject.SetActive(false);
            }
        }

        for(int i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);
            numbers[i] = 30;
        }

        for(int i = 0; i < numbersTwo.Count; i++)
        {

        }

        if(testNumber == 3)
        {

        }
        else if (testNumber == 4)
        {

        }
        else if (testNumber == 5)
        {

        }
        else if (testNumber == 10)
        {

        }
        else
        {

        }

        switch (players)
        {
            case Players.PlayerOne:
            case Players.PlayerTwo:

                break;

            case Players.PlayerThree:

                break;

            default:

                break;
        }

        //numbers = new int[10];
        /*numbers[0] = 100;
        numbers[9] = 100000;*/
        //numbersTwo = new List<int>();
        //numbersTwo[0] = 1000;
        
        //numbersTwo.Add(100);
        //trans = GameObject.Find("Main Camera").GetComponent<Transform>();
        //meshRenderer = GetComponent<MeshRenderer>();
        Debug.Log("Start");
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            Debug.Log("W");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
        }

        if (Input.GetButton("Horizontal"))
        {
            Debug.Log("Horizontal");
        }

        Debug.Log("Update");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate");

    }
}
