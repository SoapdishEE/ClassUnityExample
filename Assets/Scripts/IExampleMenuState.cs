using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class IExampleMenuState : IExample // IState
{
    public void OnSceneLoaded(){}
    public void OnStateEnter(){}
    public void OnStateExit(){}
    public void OnStateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameManager.Instance.NewGameState(new PlayState());
            //SceneManager.LoadScene("PlayScene");
        }
    }
}
