using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void startGame() {
        SceneManager.LoadScene("lvl");
    }
    public void dead() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("lvl");
        }
    }
}
