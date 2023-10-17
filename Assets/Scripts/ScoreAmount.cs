using UnityEngine;
using TMPro;

public class ScoreAmount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mScoreAmount = null;

    private int mScore;

    private void OnEnable()
    {
        Actions.IncreaseScore += AddScore;
    }

    private void OnDisable()
    {
        Actions.IncreaseScore -= AddScore;
    }

    public void AddScore(int score)
    {
        mScore += score;
        mScoreAmount.text = mScore.ToString();
    }
}
