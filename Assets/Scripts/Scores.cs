using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _highScoreUI;
    [SerializeField] TextMeshProUGUI _lastScoreUI;
    [SerializeField] float _highScore;
    [SerializeField] float _lastScore;

    private void Start()
    {
        ReportScore();
    }


    public void SetScore(float score)
    {
        _lastScore = score;
        PlayerPrefs.SetFloat("Last Score ", _lastScore);

        if (_highScore < _lastScore)
        {
            _highScore = _lastScore;
            PlayerPrefs.SetFloat("High Score ", _highScore);
        }
        else
        {
            return;
        }
        PlayerPrefs.Save();
    }

    public void ReportScore()
    {

        _lastScoreUI.text = PlayerPrefs.GetFloat("Last Score ", _lastScore).ToString();

        _highScoreUI.text = PlayerPrefs.GetFloat("High Score ", _highScore).ToString();
    }
}
