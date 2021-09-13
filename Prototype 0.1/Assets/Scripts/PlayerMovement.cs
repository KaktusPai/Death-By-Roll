using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float movementSpeed= 5f;
    public float dashSpeed = 8f;
    public bool isDashing;
    Vector2 movement;

    // References
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sr;


    void Update()
    {
        // Input
        // Check dash input
        if (Input.GetKeyDown(KeyCode.LeftShift) && movement.x > 0 && movement.y > 0)
        {
            isDashing = !isDashing;
        }
        // Check walk input only if not dashing
        if (isDashing == false)
        {
            // Check walk input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
}

    void FixedUpdate()
    {
        // Walking
        if (isDashing == false)
        {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        } else if (isDashing == true)
        {
            rb.MovePosition(rb.position + movement * dashSpeed * Time.fixedDeltaTime);
            Debug.Log("Dashing " + movement);
        }

        // Dashing

        // Flip sprite x when right
        if (movement.x == 1 && movement.y == 0)
        {
            sr.flipX = true;
        } else
        {
            sr.flipX = false;
        }
    }
}
