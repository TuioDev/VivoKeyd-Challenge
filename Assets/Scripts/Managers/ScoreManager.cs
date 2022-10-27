using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private Image ScoreFull;
    [SerializeField] private int CurrentScore;
    [SerializeField] private int MaxScore;

    public void SetMaxScore(int maxScore) => MaxScore = maxScore;
    public void AddToScore(int ammountToAdd) => ChangeCurrentScore(ammountToAdd, true);
    public void SubtractFromScore(int ammountToRemove) => ChangeCurrentScore(ammountToRemove, false);

    private void ChangeCurrentScore(int ammount, bool isToAdd)
    {
        CurrentScore += ammount * (isToAdd ? 1 : -1);
        ScoreFull.fillAmount = CurrentScore / (float)MaxScore;
    }
}
