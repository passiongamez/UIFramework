using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _mathHighScoreUI;
    [SerializeField] TextMeshProUGUI _mathLastScoreUI;
    float _mathHighScore;
    float _mathLastScore;

    [SerializeField] TextMeshProUGUI _matchHighScoreUI;
    [SerializeField] TextMeshProUGUI _matchLastScoreUI;
    float _matchHighScore;
    float _matchLastScore;

    [SerializeField] TextMeshProUGUI _shapeHighScoreUI;
    [SerializeField] TextMeshProUGUI _shapeLastScoreUI;
    float _shapeHighScore;
    float _shapeLastScore;

    private void Start()
    {
        if(_mathHighScoreUI == null)
        {
            Debug.Log("math high score text is null");
        }

        if (_mathLastScoreUI == null)
        {
            Debug.Log("math last score text is null");
        }

        if (_matchHighScoreUI == null)
        {
            Debug.Log("match high score text is null");
        }

        if (_matchLastScoreUI == null)
        {
            Debug.Log("match last score text is null");
        }

        if (_shapeHighScoreUI == null)
        {
            Debug.Log("shape high score text is null");
        }

        if (_shapeLastScoreUI == null)
        {
            Debug.Log("shape last score text is null");
        }

        _mathHighScore = PlayerPrefs.GetFloat("Math High Score");
        _matchHighScore = PlayerPrefs.GetFloat("Match High Score");
       _shapeHighScore = PlayerPrefs.GetFloat("Shape High Score");


        ReportScore();
    }


    public void SetMathScore(float score)
    {
        _mathLastScore = score;
        PlayerPrefs.SetFloat("Math Last Score", _mathLastScore);

        if (_mathHighScore < score)
        {
            _mathHighScore = score;
            PlayerPrefs.SetFloat("Math High Score", _mathHighScore);
        }

        PlayerPrefs.Save();
    }

    public void SetMatchScore(float score)
    {
        _matchLastScore = score;
        PlayerPrefs.SetFloat("Match Last Score", _matchLastScore);

        if (_matchHighScore < score)
        {
            _matchHighScore = score;
            PlayerPrefs.SetFloat("Match High Score", _matchHighScore);
        }

        PlayerPrefs.Save();
    }

    public void SetShapeScore(float score)
    {
        _shapeLastScore = score;
        PlayerPrefs.SetFloat("Shape Last Score", _shapeLastScore);

        if (_shapeHighScore < score)
        {
            _shapeHighScore = score;
            PlayerPrefs.SetFloat("Shape High Score", _shapeHighScore);
        }

        PlayerPrefs.Save();
    }

    public void ReportScore()
    {

        _mathLastScoreUI.text = PlayerPrefs.GetFloat("Math Last Score").ToString();

        _mathHighScoreUI.text = PlayerPrefs.GetFloat("Math High Score").ToString();

        _matchLastScoreUI.text = PlayerPrefs.GetFloat("Match Last Score").ToString();

        _matchHighScoreUI.text = PlayerPrefs.GetFloat("Match High Score").ToString();

        _shapeLastScoreUI.text = PlayerPrefs.GetFloat("Shape Last Score").ToString();

        _shapeHighScoreUI.text = PlayerPrefs.GetFloat("Shape High Score").ToString();
    }
}
