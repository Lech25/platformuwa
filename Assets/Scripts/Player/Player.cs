using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Scenes sceneManager;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "spike" || collision.gameObject.tag == "Enemy") {
            sceneManager.dead();
            //Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Movingplatform") {
            this.transform.parent = collision.transform;
            Debug.Log("aa");
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Movingplatform") {
            this.transform.parent = null;
            Debug.Log("bb");
        }
    }
}
