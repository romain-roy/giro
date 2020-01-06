using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform t;

    void Start()
    {
        this.t = this.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        this.t.position += new Vector3(10f, 0f, 0f) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<Animator>().Play("Explosion");
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}
