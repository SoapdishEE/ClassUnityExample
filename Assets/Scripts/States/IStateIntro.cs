using UnityEngine;
using UnityEngine.SceneManagement;

public class IStateIntro : IState
{
    private float mCountDown = 3;
    private const string MENU = "Menu";

    public void OnSceneLoaded()
    {
        
    }

    public void OnStateEnter()
    {
        Debug.Log("OnStateEnter Intro State");
    }

    public void OnStateExit()
    {
        Debug.Log("OnStateExit Intro State");
    }

    public void OnStateUpdate()
    {
        if(mCountDown > 0)
        {
            mCountDown -= Time.deltaTime;
        }
        else
        {
            GameManager.Instance.NewGameState(new IStateMenu());
            SceneManager.LoadScene(MENU);
        }
    }
}
