using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mMenuPanel = null;
    [SerializeField] private AudioSource mLevelBGMusic = null;

    public void GameStartButton()
    {
        mMenuPanel.SetActive(false);
        Actions.StartGame?.Invoke();
        StartLevelMusic();
    }

    private void StartLevelMusic()
    {
        mLevelBGMusic.Play();
    }
}
