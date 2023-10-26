using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public IState CurrentState { get; private set; }

    [SerializeField] private GameObject mMenuPanel = null;
    [SerializeField] private AudioSource mLevelBGMusic = null;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        NewGameState(new IStateIntro());
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CurrentState.OnSceneLoaded();
    }

    private void Update()
    {
        if(CurrentState != null)
        {
            CurrentState.OnStateUpdate();
        }
    }

    public void NewGameState(IState newState)
    {
        if(CurrentState != null)
        {
            CurrentState.OnStateExit();
        }

        CurrentState = newState;
        CurrentState.OnStateEnter();
    }

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
