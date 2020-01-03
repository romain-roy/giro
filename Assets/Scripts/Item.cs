using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Projectile projectile;

    private bool isPickedUp = false;
    private GameObject player;
    private Transform itemTransform;

    void Start()
    {
        itemTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (isPickedUp)
        {
            itemTransform.position = player.GetComponent<Transform>().position;
        }
    }

    public void Rotate()
    {
        itemTransform.localScale = new Vector3(player.GetComponent<Rigidbody2D>().velocity.normalized.x, 1f, 1f);
    }

    public void pickUp(GameObject player)
    {
        isPickedUp = true;
        this.player = player;
    }
}
