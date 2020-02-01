﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField]
    private float _moveSpeed;
    private Vector2 _moveInput;

    public Sprite Idle;
    public Sprite Gun;
    public GameObject BulletToFire;
    public Transform FirePoint;

    private Rigidbody2D _body;
    private SpriteRenderer _sprite;

    public bool haveGun = false;

    private float _shootTimer = 0f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal_P2");
        _moveInput.y = Input.GetAxisRaw("Vertical_P2");
        _moveInput.Normalize();

        _body.velocity = _moveInput * _moveSpeed;

        if (haveGun)
        {
            _sprite.sprite = Gun;
        }
        else
        {
            _sprite.sprite = Idle;
        }


        if (Input.GetKeyDown(KeyCode.Space) && _shootTimer <= 0)
        {
            var obj = Instantiate(BulletToFire, FirePoint.position, transform.rotation);
            var rot = 0;
            if (transform.rotation.z > 0.7f && transform.rotation.z < 1f)
                rot = 0;
            if (transform.rotation.z == 0)
                rot = -90;
            if (transform.rotation.z < -0.7f && transform.rotation.z > -1f)
                rot = 180;
            if (transform.rotation.z == -1)
                rot = 90;

            obj.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
            _shootTimer = 0.5f;
        }

        if (_shootTimer > -1)
            _shootTimer -= Time.deltaTime;



        if (_moveInput.x > 0)
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        else if (_moveInput.x < 0)
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        else if (_moveInput.y > 0)
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        else if (_moveInput.y < 0)
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
    }
}
