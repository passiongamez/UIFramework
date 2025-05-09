using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _mathHighScoreUI;
    [SerializeField] TextMeshProUGUI _mathLastScoreUI;
    [SerializeField] float _mathHighScore;
    [SerializeField] float _mathLastScore;

    [SerializeField] TextMeshProUGUI _matchHighScoreUI;
    [SerializeField] TextMeshProUGUI _matchLastScoreUI;
    [SerializeField] float _matchHighScore;
    [SerializeField] float _matchLastScore;

    [SerializeField] TextMeshProUGUI _shapeHighScoreUI;
    [SerializeField] TextMeshProUGUI _shapeLastScoreUI;
    [SerializeField] float _shapeHighScore;
    [SerializeField] float _shapeLastScore;

    private void Start()
    {
        ReportScore();
    }


    public void SetMathScore(float score)
    {
        _mathLastScore = score;
        PlayerPrefs.SetFloat("Last Score ", _mathLastScore);

        if (_mathHighScore < _mathLastScore)
        {
            _mathHighScore = _mathLastScore;
            PlayerPrefs.SetFloat("High Score ", _mathHighScore);
        }
        else
        {
            return;
        }
        PlayerPrefs.Save();
    }

    public void SetMatchScore(float score)
    {
        _matchLastScore = score;
        PlayerPrefs.SetFloat("Last Score ", _matchLastScore);

        if (_matchHighScore < _matchLastScore)
        {
            _matchHighScore = _matchLastScore;
            PlayerPrefs.SetFloat("High Score ", _matchHighScore);
        }
        else
        {
            return;
        }
        PlayerPrefs.Save();
    }

    public void SetShapeScore(float score)
    {
        _shapeLastScore = score;
        PlayerPrefs.SetFloat("Last Score ", _shapeLastScore);

        if (_shapeHighScore < _shapeLastScore)
        {
            _shapeHighScore = _shapeLastScore;
            PlayerPrefs.SetFloat("High Score ", _shapeHighScore);
        }
        else
        {
            return;
        }
        PlayerPrefs.Save();
    }

    public void ReportScore()
    {

        _mathLastScoreUI.text = PlayerPrefs.GetFloat("Last Score ", _mathLastScore).ToString();

        _mathHighScoreUI.text = PlayerPrefs.GetFloat("High Score ", _mathHighScore).ToString();

        _matchLastScoreUI.text = PlayerPrefs.GetFloat("Last Score ", _matchLastScore).ToString();

        _matchHighScoreUI.text = PlayerPrefs.GetFloat("High Score ", _matchHighScore).ToString();

        _shapeLastScoreUI.text = PlayerPrefs.GetFloat("Last Score ", _shapeLastScore).ToString();

        _shapeHighScoreUI.text = PlayerPrefs.GetFloat("HighScore ", _shapeHighScore).ToString();
    }
}
