using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float yOffset = 1f;
    private float zOffset = -3f;
    private float targetY;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        // Get the transform object of our player
        player = GameObject.Find("Player").transform;

        // Get y at beginning and keep it fixed to avoid any bug with jumping and resetting y position for animations.
        targetY = player.position.y + yOffset;
    }

    // Update is called once per frame

    // Late update so that the camera is updated after the player has moved
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z + zOffset);
    }
}
