using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionTimeline : MonoBehaviour
{
    public Button run;
    public Button reset;

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
            timeline.value += 0.01f;
            if (timeline.value >= 1f) fillTimeline = false;
        }
    }

    void FillTimeline()
    {
        fillTimeline = true;
    }

    void resetTimeline()
    {
        timeline.value = 0f;
    }
}
