using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float movementSpeed;
    private Rigidbody2D rb;
    public Transform sideR;
    public Transform sideL;
    public LayerMask groundLayers;
    float direction;

    void Start() {
        direction = -1;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        Collider2D groundCheckL = Physics2D.OverlapCircle(sideL.position, .1f, groundLayers);
        Collider2D groundCheckR = Physics2D.OverlapCircle(sideR.position, .1f, groundLayers);

        if (groundCheckL == null) {
            direction = 1;
        } else if (groundCheckR == null) {
            direction = -1;
        }
        Vector2 movement = new Vector2(direction * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
}
