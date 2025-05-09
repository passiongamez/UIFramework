using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShapeGameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timer;
    float _time = 60f;
    bool _isGameOver = false;
    [SerializeField] TextMeshProUGUI _scoreText;
    float _score = 0;
    Scores _scoreScript;
    public List<Image> _shapes = new List<Image>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _scoreScript = GameObject.Find("GameManager").GetComponent<Scores>();
      _timer.text = _time.ToString();   
    }

    // Update is called once per frame
    void Update()
    { 
        if(_isGameOver == true)
        {
            _score = _time * 50f;
            _scoreText.text = Mathf.RoundToInt( _score).ToString();
            _scoreScript.SetShapeScore(_score);
        }
        else
        {
            _time -= Time.deltaTime;
        }

        _timer.text = Mathf.RoundToInt(_time).ToString();

        if (_time <= 0)
        {
            _isGameOver = true;
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void AddToList(Image image)
    {
        _shapes.Add(image);
    }

    public void RemoveFromList(Image image)
    {
        _shapes.Remove(image);

        if(_shapes.Count <= 0)
        {
            _isGameOver = true;
        }
    }
}
