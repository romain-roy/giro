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
    }

    void Left()
    {
        force = Vector2.left * moveForce;
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(force, ForceMode2D.Impulse);
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
