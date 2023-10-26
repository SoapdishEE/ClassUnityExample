using UnityEngine;
using UnityEngine.SceneManagement;

public class IExampleIntro : IExample
{
    private float mCountDown = 3;

    public void OnSceneLoaded(){}
    public void OnStateEnter(){}
    public void OnStateExit(){}
    public void OnStateUpdate()
    {
        if(mCountDown > 0)
        {
            mCountDown -= Time.deltaTime;
        }
        else
        {
            //GameManager.Instantiate.NewGame(new NewState());
            //SceneManager.LoadScene("MenuGame");
        }
    }
}
