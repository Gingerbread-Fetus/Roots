using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction playerControls;
    public float moveSpeed = 5f;
    [HideInInspector]
    public Vector2 moveDirection;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    Rigidbody2D rb;
    Health health;
    Animator animator;

    private void OnEnable()
    {
        playerControls.Enable();
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void OnDestroy()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();

        if (moveDirection.x != 0f || moveDirection.y != 0f)
        {
            lastHorizontalVector = moveDirection.x;
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetBool("Idle Left", false);
            animator.SetBool("Idle Right", false);
        }
        else
        {
            if(lastHorizontalVector <= 0)
            {
                animator.SetBool("Idle Left", true);
                animator.SetBool("Idle Right", false);
            }
            else if(lastHorizontalVector > 0)
            {
                animator.SetBool("Idle Left", false);
                animator.SetBool("Idle Right", true);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health.dealDamage(1);
        }
    }
}
