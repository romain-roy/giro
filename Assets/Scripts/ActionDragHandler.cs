using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform TimelineRect;
    public GameManager gameManager;
    public Action action;

    private float x_pos;
    private RectTransform SlotRect;

    private void Start()
    {
        SlotRect = transform.parent as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = GetMousePosition();
        gameManager.RemoveAction(action);
        if (isOnTimeline())
        {
            (transform as RectTransform)?.SetParent(TimelineRect);
            x_pos = ((RectTransform) transform).anchoredPosition.x;
            if (x_pos < -285) x_pos = -285;
            if (x_pos > 285) x_pos = 285;
            ((RectTransform) transform).anchoredPosition = new Vector3(x_pos, -10);
        }
        else
        {
            (transform as RectTransform)?.SetParent(SlotRect);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(isOnTimeline())
        {
            //update Action
            action.executionTime = (x_pos + 285) / 570.0f;
            gameManager.AddAction(action);
        }
        else
        {
            //reset the position
            ((RectTransform) transform).anchoredPosition = Vector3.zero;
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
