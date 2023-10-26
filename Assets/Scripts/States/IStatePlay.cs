using UnityEngine;
using UnityEngine.SceneManagement;

public class IStatePlay : IState
{
    private const string INTRO = "Intro";
    private const string MENU = "Menu";

    public void OnSceneLoaded()
    {
        
    }

    public void OnStateEnter()
    {
        Debug.Log("OnStateEnter PlayScreen");
    }

    public void OnStateExit()
    {
        Debug.Log("OnStateExit PlayScreen");
    }

    public void OnStateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            GameManager.Instance.NewGameState(new IStateIntro());
            SceneManager.LoadScene(INTRO);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.NewGameState(new IStateMenu());
            SceneManager.LoadScene(MENU);
        }
    }
}
