using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D body;
    SpriteRenderer sprite;

    float horizontal;
    float vertical;
    bool running = false;

    public float runSpeed = 5.0f;
    public float walkSpeed = 3.0f;
    public string playerNumber = "P1";
    Vector2 movement;
    public Sprite idle;
    public Sprite gun;
    public bool haveGun = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal_" + playerNumber); // -1 is left
        vertical = Input.GetAxisRaw("Vertical_" + playerNumber); // -1 is down
        running = Input.GetButton("Fire2_" + playerNumber);
        movement.x = horizontal;
        movement.y = vertical;
        if (haveGun)
        {
            sprite.sprite = gun;
        } else
        {
            sprite.sprite = idle;
        }
    }

    void FixedUpdate()
    {
        float speed = (running ? runSpeed : walkSpeed);
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
        // 0 = Right
        // 90 - Down
        // -90 - Up
        // 180 - Left
        if (horizontal > 0)
            body.MoveRotation(0);
        else if (horizontal < 0)
            body.MoveRotation(180);
        else if (vertical > 0)
            body.MoveRotation(90);
        else if (vertical < 0)
            body.MoveRotation(-90);


    }
}
