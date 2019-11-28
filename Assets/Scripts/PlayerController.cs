using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float speed;

    private Rigidbody2D rigidBody;
    private Transform playerTransform;

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
    }

    void Jump()
    {
        Debug.Log("Jump");
        rigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    void Right()
    {
        Debug.Log("Right");
        playerTransform.position += transform.right * speed * Time.deltaTime;
    }

    void Left()
    {
        Debug.Log("Left");
        playerTransform.position += -transform.right * speed * Time.deltaTime;
    }

    void Wait()
    {
        Debug.Log("Wait");
    }
}
