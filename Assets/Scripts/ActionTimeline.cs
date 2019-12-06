using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActionTimeline : MonoBehaviour
{
    public Button run;
    public Button reset;
    public float duration;
	public GameObject player;

    private Slider timeline;
    private bool fillTimeline = false;

    void Start()
    {
        run.onClick.AddListener(FillTimeline);
        reset.onClick.AddListener(resetTimeline);

        timeline = gameObject.GetComponent<Slider>();
        timeline.interactable = false;
    }

    void Update()
    {
        if (fillTimeline)
        {
            timeline.value += Time.deltaTime / duration;
            if (timeline.value >= 1f) fillTimeline = false;
        }
    }

    void FillTimeline()
    {
        fillTimeline = true;
    }

    void resetTimeline()
    {
        // timeline.value = 0f;
        // fillTimeline = false;
		// player.GetComponent<Transform>().position = new Vector3(-6.5f, -0.5f, 0f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool isRunning
    {
        get { return fillTimeline; }
    }

    public float getCurrentTime()
    {
        return timeline.value;
    }
}
