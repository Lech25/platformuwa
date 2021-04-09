using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour 
{
    public Rigidbody2D rb;
    public float direction;
    public float bulletSpeed;
    public Transform transform;
    public Transform player;
    void Start()
    {
        
        GameObject pl = GameObject.FindGameObjectWithTag("Player");
        player = pl.GetComponent<Transform>();
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(direction * bulletSpeed, 0));
    }
    private void FixedUpdate() {
        if (transform.position.x > player.position.x + 17 || transform.position.x < player.position.x -17) Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ground" || collision.tag == "Slippery") Destroy(this.gameObject);
        if (collision.tag == "Enemy") {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
