using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpForce;
    float startJumpForce;
    float jumps = 2;
    public Transform feet;
    public Transform sideL;
    public Transform sideR;
    public LayerMask groundLayers;

    float mx;
    void Start()
    {
        startJumpForce = jumpForce;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        if (isGrounded()) {
            jumps = 2;
            jumpForce = startJumpForce;
        } else if (!isGrounded() && jumps == 2) {
            jumps--;
            jumpForce *= 0.7f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumps > 0) Jump(); 
        if (isWalled() && Input.GetAxisRaw("Horizontal") != 0) jumps++;
    }
    private void FixedUpdate() {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
    void Jump() {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
        jumpForce *= 0.7f;
        jumps--;
        if (jumps == 0) jumpForce = startJumpForce;
    }
    public bool isGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if(groundCheck != null) return true;
        return false;
    }
    public bool isWalled() {
        Collider2D wallCheckL = Physics2D.OverlapCircle(sideL.position, 0.5f, groundLayers);
        Collider2D wallCheckR = Physics2D.OverlapCircle(sideR.position, 0.5f, groundLayers);

        if ((wallCheckR != null || wallCheckL != null) && Input.GetAxisRaw("Horizontal") != 0) {
            jumpForce = startJumpForce * 1.2f;
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "spike") {
            Destroy(this.gameObject);
        }
    }
}
