using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHolder : MonoBehaviour
{
    public int _slotNumber;
    Image _image;
    GameObject _shapeContainer;

    void Start()
    {
        _image = GetComponent<Image>();
        _shapeContainer = this.gameObject;
    }
    public int GetSlotNumber()
    {
        return _slotNumber;
    }
}
