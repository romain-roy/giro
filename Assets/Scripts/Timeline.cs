using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public Button valider;

    private Slider timeline;
    private bool fillTimeline = false;

    void Start()
    {
        valider.onClick.AddListener(FillTimeline);

        timeline = gameObject.GetComponent<Slider>();
        timeline.interactable = false;
    }

    void Update()
    {
        if (fillTimeline && timeline.value < 1)
            timeline.value += 0.01f;
    }

    void FillTimeline()
    {
        fillTimeline = true;
    }
}
