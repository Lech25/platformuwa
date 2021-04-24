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
       
        if(direction == 1)
            transform.position = new Vector2(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y);
        else if(direction == -1)
            transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "R") direction = -1;
        if (collision.gameObject.tag == "L") direction = 1;
    }
}
