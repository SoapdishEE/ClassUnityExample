using UnityEngine;
using UnityEngine.SceneManagement;

public class IStateMenu : IState
{
    private const string PLAY_SCREEN = "PlayScreen";

    public void OnSceneLoaded()
    {
        
    }

    public void OnStateEnter()
    {
        Debug.Log("OnStateEnter Menu");
    }

    public void OnStateExit()
    {
        Debug.Log("OnStateExit Menu");
    }

    public void OnStateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.NewGameState(new IStatePlay());
            SceneManager.LoadScene(PLAY_SCREEN);
        }
    }
}
