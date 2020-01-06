using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private Transform t;

    void Start()
    {
        this.t = this.gameObject.transform;
    }

    void Update()
    {
        t.Rotate(0f, 0f, -0.5f);
        t.localScale = new Vector3(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f));
    }
}
