using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ActionTimeline timeline;
    [SerializeField] private PlayerController playerController;

    private PriorityQueue<Action> actionsQueue;

    void Start()
    {
        actionsQueue = new PriorityQueue<Action>();

    }

    // Update is called once per frame
    void Update()
    {
        if(actionsQueue.Count != 0 && timeline.isRunning)
        { 
            Action action = actionsQueue.Peek();
            if (timeline.getCurrentTime() >= action.executionTime)
            {
                actionsQueue.Dequeue();
                playerController.ExecuteAction(action.actionType);
            }
        }
		if (!timeline.isRunning) playerController.ExecuteAction(ActionType.Stop);
    }

    public void AddAction(Action action)
    {
        actionsQueue.Enqueue(action);
    }

    public void RemoveAction(Action action)
    {
        actionsQueue.Remove(action);
    }


}
