using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MathGame : MonoBehaviour
{
    [SerializeField] Scores _scoresScript;
    [SerializeField] ScenePicker _scenePicker;
    [SerializeField] TextMeshProUGUI _number1Text;
    [SerializeField] TextMeshProUGUI _number2Text;
    [SerializeField] TextMeshProUGUI _mathSign;
    [SerializeField] TextMeshProUGUI _timer;
    [SerializeField] TextMeshProUGUI _debugText;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TMP_InputField _answerInput;
    [SerializeField] UnityEngine.UI.Button _nextQuestionButton;
    [SerializeField] UnityEngine.UI.Button _nextSceneButton;
    [SerializeField] float _time = 60f;
    [SerializeField] bool _isTimeOver = false;
    [SerializeField] string[] _mathSigns = new string[] { "+", "-", "/", "*" };
    [SerializeField] float _answer;
    [SerializeField] float _number1;
    [SerializeField] float _number2;
    float _score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _scoresScript = GameObject.Find("GameManager").GetComponent<Scores>();
        _scenePicker = GameObject.Find("GameManager").GetComponent<ScenePicker>();
        _timer.text = _time.ToString();
        _scoreText.text = 0.ToString();
        _nextQuestionButton.gameObject.SetActive(true);
        _nextSceneButton.gameObject.SetActive(false);
        StartMathProblem();
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        _timer.text = Mathf.RoundToInt(_time).ToString();

        if (_time <= 0)
        {
            _time = 0;
            _isTimeOver = true;
        }

        if(_isTimeOver == true)
        {
            _scoresScript.SetScore(_score);
            _nextQuestionButton.gameObject.SetActive(false);
            _nextSceneButton.gameObject.SetActive(true);
        }
    }


    public void StartMathProblem()
    {
        if(_isTimeOver == false)
        {
            _number1 = Random.Range(1, 100);
            _number2 = Random.Range(1, 100);
            _number1Text.text = _number1.ToString();
            _number2Text.text = _number2.ToString();
            _mathSign.text = _mathSigns[Random.Range(0, _mathSigns.Length)];

            switch (_mathSign.text)
            {
                case "+":
                    _answer = _number1 + _number2;
                    break;
                case "-":
                    _answer = _number1 - _number2;
                    break;
                case "/":
                    _answer = _number1 / _number2;
                    break;
                case "*":
                    _answer = _number1 * _number2;
                    break;
            }
        }
    }

    public void CheckAnswer()
    {
        if(_isTimeOver == false)
        {
            if (_answerInput.text == _answer.ToString())
            {
                _debugText.text = "Congratulations, you are correct!";
                _score += 10;
                _scoreText.text = _score.ToString();
                StartMathProblem();
                _answerInput.text = "";
            }
            else
            {
                _debugText.text = "Incorrect. Try again.";
            }
        }
    }

    public void Results()
    {
        _scenePicker.ResultsScreen();
    }
}
