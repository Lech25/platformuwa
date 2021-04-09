using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {
    public GameObject finishPanel;

    void Start() {
        finishPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") finishPanel.SetActive(true);
    }
}
