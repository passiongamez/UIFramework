using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    TMP_Dropdown _gameDropdown;
    [SerializeField] GameObject _mathScore;
    [SerializeField] GameObject _matchScore;
    [SerializeField] GameObject _shapeScore;
    List<string> _options = new List<string>();

    private void Start()
    {
        _gameDropdown = GetComponent<TMP_Dropdown>();

        _gameDropdown.ClearOptions();

        _options = new List<string> { "Math Game", "Match Game", "Shape Game" };

        _gameDropdown.AddOptions(_options);

        _gameDropdown.onValueChanged.AddListener(DropdownValues);
    }

    public void DropdownValues(int index)
    {
        switch (index)
        {
            case 0:
                _mathScore.SetActive(true);
                _matchScore.SetActive(false);
                _shapeScore.SetActive(false);
                break;
            case 1:
                _mathScore.SetActive(false);
                _matchScore.SetActive(true);
                _shapeScore.SetActive(false);
                break;
            case 2:
                _mathScore.SetActive(false);
                _matchScore.SetActive(false);
                _shapeScore.SetActive(true);
                break;
        }
    }
}
