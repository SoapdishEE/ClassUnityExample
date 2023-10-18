using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mMenuPanel = null;

    public void GameStartButton()
    {
        mMenuPanel.SetActive(false);
        Actions.StartGame?.Invoke();
    }
}
