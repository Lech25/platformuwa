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
        } else if(collision.gameObject.tag == "Movingplatform") {
            gameObject.transform.SetParent(collision.gameObject.transform, true);
            Debug.Log("aa");
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Movingplatform") {
            gameObject.transform.parent = null;
            Debug.Log("bb");
        }
    }
}
