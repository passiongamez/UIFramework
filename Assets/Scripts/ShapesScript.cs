using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using NUnit.Framework;

public class ShapesScript : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public int _shapeNumber;
    Image _shapeImage;
    GameObject _shapeSlot;
    DropHolder _dropHolder;
    ShapeGameManager _gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = GameObject.Find("ShapeMatch Manager").GetComponent<ShapeGameManager>();

        _shapeImage = GetComponent<Image>();

        _gameManager.AddToList(_shapeImage);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _shapeSlot = transform.gameObject;
        _shapeImage.raycastTarget = false;
        _shapeImage.transform.SetParent(_shapeSlot.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var raycasterResults = new List<RaycastResult>();
        GetComponentInParent<GraphicRaycaster>().Raycast(eventData, raycasterResults);

        for(int i = 0; i < raycasterResults.Count; i++)
        {
            if (raycasterResults[i].gameObject.TryGetComponent<DropHolder>(out DropHolder _dropHolder))
            {
                _shapeImage.transform.SetParent(_dropHolder.transform);
                _shapeImage.transform.SetAsLastSibling();
                //_shapeImage.rectTransform.localPosition = Vector3.zero;
                break;
            }
        }

        if (_dropHolder == null)
        {
            _shapeImage.transform.SetParent(_shapeSlot.transform);
            _shapeImage.raycastTarget = true;
            CheckNumber();
        }
    }

    void CheckNumber()
    {
        if(_shapeImage.transform.GetComponentInParent<DropHolder>().GetSlotNumber() == _shapeNumber)
        {
            _shapeImage.raycastTarget = false;
            _gameManager.RemoveFromList(_shapeImage);
        }
        _dropHolder = null;
    }
}
