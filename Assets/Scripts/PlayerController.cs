using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float moveForce;

    private Rigidbody2D rigidBody;
    private Transform playerTransform;
    private Animator animator;
    private Vector2 force = Vector2.zero;
    private bool hasItem = false;
    private GameObject item;
    private bool hasWin = false;

    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        playerTransform = this.gameObject.GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) this.Jump();
        if (Input.GetKeyDown(KeyCode.RightArrow)) this.Right();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) this.Left();
        if (Input.GetKeyDown(KeyCode.W)) StartCoroutine(Wait());
        if (Input.GetKeyDown(KeyCode.A)) Stop();
        if (Input.GetKeyDown(KeyCode.E)) UseItem();
    }

    void Stop()
    {
        animator.SetBool("isWalking", false);
        rigidBody.velocity = Vector2.zero;
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Right()
    {
        animator.SetBool("isWalking", true);
        force = Vector2.right * moveForce;
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(force, ForceMode2D.Impulse);
        if (hasItem) item.GetComponent<Item>().Rotate();
    }

    void Left()
    {
        animator.SetBool("isWalking", true);
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

        if (other.gameObject.CompareTag("Levier"))
        {
            GameObject laser = GameObject.FindGameObjectWithTag("Laser");
            if (laser != null)
                laser.SetActive(!laser.activeSelf);
        }

        if (other.gameObject.CompareTag("Laser"))
        {
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            rigidBody.velocity = new Vector2(0f, 0f);
            hasWin = true;
        }
    }

    public bool getHasWin()
    {
        return this.hasWin;
    }

    IEnumerator Wait()
    {
        animator.SetBool("isWalking", false);
        Vector2 f = force;
        rigidBody.velocity = Vector2.zero;
        yield return new WaitForSeconds(1.0f);
        force = f;
        rigidBody.AddForce(force, ForceMode2D.Impulse);
        animator.SetBool("isWalking", true);
    }

    public void ExecuteAction(ActionType action)
    {
        switch (action)
        {
            case ActionType.MoveRight:
                Right();
                break;
            case ActionType.MoveLeft:
                Left();
                break;
            case ActionType.Pause:
                StartCoroutine(Wait());
                break;
            case ActionType.Jump:
                Jump();
                break;
            case ActionType.Fire:
                UseItem();
                break;
            case ActionType.Stop:
                Stop();
                break;
        }
    }
}
