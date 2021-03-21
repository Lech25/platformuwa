using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform camera;
    public Transform player;
    void Start()
    {
        camera = GetComponent<Transform>();
    }

    void Update()
    {
        camera.position = player.position + new Vector3(0, 2, -10);
    }
}
