using UnityEngine;

public class IExamplePlayState : IExample
{
    private GameObject mPausePanel;
    private bool mIsPaused = false;
    private float mFixedDeltaTime;

    public void OnSceneLoaded()
    {
        mPausePanel.SetActive(false);
    }
    public void OnStateEnter()
    {
        Cursor.visible = mIsPaused;
        mFixedDeltaTime = Time.fixedDeltaTime;
        Cursor.visible = false;
    }
    public void OnStateExit()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this.mFixedDeltaTime * Time.timeScale;
    }

    public void OnStateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            mIsPaused = !mIsPaused;
            Cursor.visible = mIsPaused;
            Time.timeScale = mIsPaused ? 0.0f : 1.0f;
            Time.fixedDeltaTime = this.mFixedDeltaTime * Time.timeScale;
            mPausePanel.SetActive(mIsPaused);
        }    
    }
}
