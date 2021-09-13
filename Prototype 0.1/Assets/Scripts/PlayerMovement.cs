using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float movementSpeed= 5f;
    public float dashSpeed = 8f;
    public float dashDuration = 2f;
    public int dashCharges = 3;
    public float dashChargeCooldown = 4f;
    [SerializeField] private float dashChargeTime;
    [SerializeField] private float totalDashTime;
    public bool isDashing;
    Vector2 movement;
    // References
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sr;
    // UI
    public Image cooldownImage;
    public Image charge3;
    public Image charge2;
    public Image charge1;
    public Color chargeColor1 = Vector4.one;
    public Color chargeColor2 = Vector4.one;
    public Color chargeColor3 = Vector4.one;
    void Start()
    {
        cooldownImage.gameObject.SetActive(false);
        // Begin with 3 dashes 
        dashChargeTime = dashChargeCooldown * dashCharges;
        // Dash cooldown UI naar 0
        cooldownImage.fillAmount = 0;
        // Set total dash time
        totalDashTime = dashChargeCooldown * dashCharges;
    }
    void Update()
    {
        // Input
        // Check dash input
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (movement != Vector2.zero && dashCharges > 0)
            {
                Dash();
            }
        }
        // Check walk input only if not dashing
        if (isDashing == false)
        {
            GetWalkInput();
        }

        // Dashing charge logic
        DashChargeUpdate();
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

        // Flip sprite x when right
        FlipSprite2Right();
    }

    void GetWalkInput()
    {
        // Check walk input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void Dash()
    {
        isDashing = true;
        dashChargeTime -= dashChargeCooldown;
        isDashing = false;

    }

    void DashChargeUpdate()
    {
        // Update charges and charges UI
        if (dashChargeTime < totalDashTime)
        {
            // Timer adds every second
            dashChargeTime += Time.deltaTime;
            // Change color to lightly transparent
            chargeColor3.a = 0.2f;
            charge3.color = chargeColor3;
            //Update charges index
            dashCharges = 2;

            if (dashChargeTime <= dashChargeCooldown * 2)
            {
                chargeColor2.a = 0.2f;
                charge2.color = chargeColor2;
                dashCharges = 1;

                if (dashChargeTime <= dashChargeCooldown)
                {
                    chargeColor1.a = 0.2f;
                    charge1.color = chargeColor1;
                    dashCharges = 0;

                    cooldownImage.gameObject.SetActive(true);
                    cooldownImage.fillAmount = (dashChargeTime / dashChargeCooldown);
                }
                else
                {
                    charge1.color = chargeColor1;
                    chargeColor1 = Vector4.one;
                    cooldownImage.gameObject.SetActive(false);
                }
            }
            else
            {
                charge2.color = chargeColor2;
                chargeColor2 = Vector4.one;
            }
        }
        else
        {
            // Change color transparancy to normal
            charge3.color = chargeColor3;
            chargeColor3 = Vector4.one;

            cooldownImage.gameObject.SetActive(false);
        }
    }
    void FlipSprite2Right()
    {
        if (movement.x == 1 && movement.y == 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
