using UnityEngine;
using UnityEngine.UI;

public class HudPanel : MonoBehaviour
{
    [SerializeField] private Image panelImage = null;
    [SerializeField] private GameObject ScoreText = null;
    [SerializeField] private GameObject Health = null;

    private void OnEnable()
    {
        Actions.StartGame += ShowHud;
    }

    private void OnDisable()
    {
        Actions.StartGame -= ShowHud;
    }

    private void Start()
    {
        panelImage.enabled = false;
        ScoreText.SetActive(false);
        Health.SetActive(false);
    }

    public void ShowHud()
    {
        panelImage.enabled = true;
        ScoreText.SetActive(true);
        Health.SetActive(true);
    }
}
