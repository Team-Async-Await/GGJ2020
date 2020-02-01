using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    bool running = false;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;
    public float walkSpeed = 3.0f;
    public string playerNumber = "P1";

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal_" + playerNumber); // -1 is left
        vertical = Input.GetAxisRaw("Vertical_" + playerNumber); // -1 is down
        running = Input.GetButton("Fire2_" + playerNumber);
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        float speed = (running ? runSpeed : walkSpeed);
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
