using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    TMP_Dropdown _gameDropdown;
    [SerializeField] GameObject _mathScore;
    [SerializeField] GameObject _matchScore;
    [SerializeField] GameObject _shapeScore;

    private void Update()
    {
        if(_gameDropdown.value == 0)
        {
            _mathScore.SetActive(true);
        }
        else if(_gameDropdown.value == 1)
        {
            _matchScore.SetActive(true);
        }
        else
        {
            _shapeScore.SetActive(true);
        }
    }
}
