using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject victoryPanel;
    public Button nextLevel;

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
        if (actionsQueue.Count != 0 && timeline.isRunning)
        {
            Action action = actionsQueue.Peek();
            if (timeline.getCurrentTime() >= action.executionTime)
            {
                actionsQueue.Dequeue();
                playerController.ExecuteAction(action.actionType);
            }
        }
        if (!timeline.isRunning) playerController.ExecuteAction(ActionType.Stop);

        if (playerController.getHasWin())
        {
            victoryPanel.SetActive(true);
            StartCoroutine("MaximiseVictoryPanel");
            nextLevel.onClick.AddListener(changeLevel);
        }
    }

    public void AddAction(Action action)
    {
        actionsQueue.Enqueue(action);
    }

    public void RemoveAction(Action action)
    {
        actionsQueue.Remove(action);
    }

    IEnumerator MaximiseVictoryPanel()
    {
        while (victoryPanel.transform.localScale.x <= 0.7f)
        {
            victoryPanel.transform.localScale += new Vector3(0.01f, 0.0085f, 0f);
            victoryPanel.transform.Rotate(0f, 0f, 5f, Space.Self);
            yield return new WaitForSeconds(.1f);
        }
    }

    void changeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
