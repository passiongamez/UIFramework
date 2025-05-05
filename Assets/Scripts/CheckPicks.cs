using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckPicks : MonoBehaviour
{
    MatchScript _matchScript;

    private void Start()
    {
        _matchScript = GameObject.Find("MatchGame Master").GetComponent<MatchScript>();

        if(_matchScript == null)
        {
            Debug.Log("Match script is null");
        }
    }

    public void PickButton()
    {
        _matchScript.AssignPick(this.gameObject);
    }
}
