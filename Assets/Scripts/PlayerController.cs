using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float moveForce;

    private Rigidbody2D rigidBody;
    private Transform playerTransform;
    private Vector2 force = Vector2.zero;
    private bool hasItem = false;
    private GameObject item;

    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        playerTransform = this.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) this.Jump();
        if (Input.GetKeyDown(KeyCode.RightArrow)) this.Right();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) this.Left();
        if (Input.GetKeyDown(KeyCode.W)) StartCoroutine(Wait());
        if (Input.GetKeyDown(KeyCode.A)) Stop();
        if (Input.GetKeyDown(KeyCode.E)) UseItem();
    }

    void Stop()
    {
        rigidBody.velocity = Vector2.zero;
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Right()
    {
        force = Vector2.right * moveForce;
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(force, ForceMode2D.Impulse);
        if (hasItem) item.GetComponent<Item>().Rotate();
    }

    void Left()
    {
        force = Vector2.left * moveForce;
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(force, ForceMode2D.Impulse);
        if (hasItem) item.GetComponent<Item>().Rotate();
    }

    void UseItem()
    {
        if (hasItem)
        {
            item.SetActive(false);
        }
        else
        {
            // impossible -> feedback audio
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            item = other.gameObject;
            hasItem = true;
            item.GetComponent<Item>().pickUp(this.gameObject);
        }
    }

    IEnumerator Wait()
    {
        Vector2 f = force;
        rigidBody.velocity = Vector2.zero;
        yield return new WaitForSeconds(1.0f);
        force = f;
        rigidBody.AddForce(force, ForceMode2D.Impulse);
    }
}
