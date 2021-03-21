using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public BulletShoot bulletPrefab;
    public Transform playerTransform;

    float direction; //left -1, right 1

    void Start() {
        direction = 1;
    }

    void Update() {
        if (Input.GetAxisRaw("Horizontal") == 1) direction = 1;
        else if (Input.GetAxisRaw("Horizontal") == -1) direction = -1;

        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
    }

    void Shoot() {
        BulletShoot bullet = Instantiate(bulletPrefab, new Vector2(playerTransform.position.x + direction, playerTransform.position.y), Quaternion.identity) as BulletShoot;
        bullet.direction = direction;
    }
}
