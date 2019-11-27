using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform TimelineRect; 
    
    RectTransform SlotRect;

    private void Start()
    {
        SlotRect = transform.parent as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = GetMousePosition();

        if (isOnTimeline())
        {
            (transform as RectTransform).SetParent(TimelineRect);
            (transform as RectTransform).anchoredPosition = new Vector3((transform as RectTransform).anchoredPosition.x, -10);
        }
        else
        {
            (transform as RectTransform).SetParent(SlotRect);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(isOnTimeline())
        {
           //update Action Items 
        }
        else
        {
            //reset the position
            (transform as RectTransform).anchoredPosition = Vector3.zero;
        }
    }

    private bool isOnTimeline()
    {
        return RectTransformUtility.RectangleContainsScreenPoint(TimelineRect, Input.mousePosition, Camera.main);
    }

    Vector3 GetMousePosition()
    {
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            Input.mousePosition, Camera.main,
            out movePos);

        Vector3 positionToReturn = transform.TransformPoint(movePos);

        return positionToReturn;
    }
}
