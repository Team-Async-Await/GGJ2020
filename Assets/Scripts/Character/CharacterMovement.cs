using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    bool running = false;

    public float runSpeed = 5.0f;
    public float walkSpeed = 3.0f;
    public string playerNumber = "P1";
    Vector2 movement;
    public Sprite idle;
    public Sprite gun;

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
        movement.x = horizontal;
        movement.y = vertical;
    }

    void FixedUpdate()
    {
        float speed = (running ? runSpeed : walkSpeed);
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
    }
}
