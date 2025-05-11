using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MatchScript : MonoBehaviour
{
    [SerializeField] Image[] _matchCards;
    [SerializeField] GameObject _gridParent;
    [SerializeField] TextMeshProUGUI _timer;
    float _time = 60f;
    bool _isGameOver = false;
    [SerializeField] GameObject _cardPick1;
    [SerializeField] GameObject _cardPick2;
    Button _button;
    [SerializeField] TextMeshProUGUI _textScore;
    [SerializeField] Button _nextButton;
    float _score = 0;
    List<Image> cardPool;
    Scores _scoreScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        _scoreScript = GameObject.Find("GameManager").GetComponent<Scores>();
        //PlayerPrefs.GetFloat("Match High Score").ToString();
        _timer.text = Mathf.RoundToInt(_time).ToString();
        _nextButton.gameObject.SetActive(false);
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        _timer.text = Mathf.RoundToInt(_time).ToString();

        if(_time <= 0)
        {
            _time = 0;
            _isGameOver = true;
            _nextButton.gameObject.SetActive(true);
            _scoreScript.SetMatchScore(_score);
        }
    }

    public void NewGame()
    {
        cardPool = new List<Image>();

        foreach (Image card in _matchCards)
        {
            cardPool.Add(card);
            cardPool.Add(card);
        }

        for (int i = 0; i < cardPool.Count; i++)
        {
            Image randomCard = cardPool[i];
            int randomNumber = Random.Range(i, cardPool.Count);
            cardPool[i] = cardPool[randomNumber];
            cardPool[randomNumber] = randomCard;
        }

        foreach(Image card in cardPool)
        {
            Image temp = Instantiate(card);
            temp.transform.SetParent(_gridParent.transform, false);
        }
    }

    public void ResetGame()
    {
        for(int i = _gridParent.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = _gridParent.transform.GetChild(i);
            Destroy(child.gameObject);
        }

        NewGame();

        if(_time <= 0)
        {
            _time = 60f;
        }
    }
    

    public void AssignPick(GameObject temp)
    {
        if(_cardPick1 == null)
        {
            _cardPick1 = temp;
        }
        else
        {
            _cardPick2 = temp;
        }

        if (_isGameOver == false)
        {
            if (_cardPick1 != null && _cardPick2 != null)
            {
                if (_cardPick1.transform.parent.name == _cardPick2.transform.parent.name)
                {
                    Invoke("CorrectChoice", .5f);
                }
                else
                {
                    Invoke("ResetButton", .5f);
                }
            }
        }
    }

    public void UpdateScore()
    {
        _score += 10;
        _textScore.text = _score.ToString();
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    void CorrectChoice()
    {
        _cardPick1.transform.parent.gameObject.GetComponent<Image>().enabled = false;
        _cardPick2.transform.parent.gameObject.GetComponent<Image>().enabled = false;
        UpdateScore();
        _cardPick1 = null;
        _cardPick2 = null;
    }

    void ResetButton()
    {
        _cardPick1.GetComponent<Image>().enabled = true;
        _cardPick1.GetComponent<Button>().interactable = true;
        _cardPick2.GetComponent<Image>().enabled = true;
        _cardPick2.GetComponent<Button>().interactable = true;
        _cardPick1 = null;
        _cardPick2 = null;
    }
}
