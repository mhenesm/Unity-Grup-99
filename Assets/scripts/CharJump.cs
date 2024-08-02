using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharJump : MonoBehaviour
{
    [SerializeField] int can = 3;
    public GameObject can1;
    public GameObject can2;
    public GameObject can3;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded =true;
    private Animator animator;
    public Transform referansDeath;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            animator.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")|| collision.gameObject.CompareTag("nonengel"))
        {
            isGrounded = true;
            animator.enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("nonengel"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gold"))
        {
            collision.gameObject.transform.position = referansDeath.position;

        }
        if (collision.gameObject.CompareTag("engel"))
        {
            Destroy(collision.gameObject);
            can--;
            kalpMove();
        }
    }

    private void kalpMove()
    {
        if (can == 2)
        {
            can3.gameObject.transform.position = referansDeath.position;
        }
        if (can == 1)
        {
            can2.gameObject.transform.position = referansDeath.position;
        }
        if (can == 0)
        {
            can1.gameObject.transform.position = referansDeath.position;
        }
    }

}
