using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    private Vector2 _moveInput;

    public int CurrentHealth;
    public int MaxHealth;

    public Sprite Idle;
    public Sprite Gun;
    public GameObject BulletToFire;
    public Transform FirePoint;

    private Rigidbody2D _body;
    private SpriteRenderer _sprite;
    public float BulletLifeTime = 0.25f;

    public bool haveGun = false;

    private float _shootTimer = 0f;

    public string PlayerNumber = "P2";
    private Vector2 Direction;

    public bool Pressed { get; internal set; }
    public Vector2 LastAcceleration { get; set; }

    private void Awake()
    {
        if (PlayerNumber == "P1")
        {
            LevelController.Player1 = this;
        }
        else
        {
            LevelController.Player2 = this;
        }
    }

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal_" + PlayerNumber);
        _moveInput.y = Input.GetAxisRaw("Vertical_" + PlayerNumber);
        _moveInput.Normalize();

        //_body.velocity = _moveInput * _moveSpeed;

        if (haveGun)
        {
            _sprite.sprite = Gun;
        }
        else
        {
            _sprite.sprite = Idle;
        }

        Move(_moveInput);


        if (Input.GetButtonDown("Fire1_" + PlayerNumber))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2_" + PlayerNumber))
        {
            Action();
        }

        if (_shootTimer > -1)
            _shootTimer -= Time.deltaTime;



        //if (_moveInput.x > 0)
        //    transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        //else if (_moveInput.x < 0)
        //    transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        //else if (_moveInput.y > 0)
        //    transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        //else if (_moveInput.y < 0)
        //    transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
    }

    public void Move(Vector2 moveInput)
    {
        if (!(moveInput.x == 0 && moveInput.y == 0))
            LastAcceleration = moveInput;

        if (Pressed)
            _body.velocity = LastAcceleration * _moveSpeed;
        else
            _body.velocity = moveInput * _moveSpeed;

        if (moveInput.x > 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            Direction = new Vector2(1, 0);
        }
        else if (moveInput.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            Direction = new Vector2(-1, 0);
        }
        else if (moveInput.y > 0)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            Direction = new Vector2(0, 1);
        }
        else if (moveInput.y < 0)
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            Direction = new Vector2(0, -1);
        }
    }

    public void Shoot()
    {
        if (_shootTimer <= 0)
        {
            AudioManager.Instance.PlaySfx(6);
            var obj = Instantiate(BulletToFire, FirePoint.position, transform.rotation);
            Destroy(obj, BulletLifeTime);
            var rot = 0;
            if (transform.rotation.z > 0.7f && transform.rotation.z < 1f)
                rot = 0;
            if (transform.rotation.z == 0)
                rot = -90;
            if (transform.rotation.z < -0.7f && transform.rotation.z > -1f)
                rot = 180;
            if (Mathf.Abs(transform.rotation.z) == 1)
                rot = 90;

            Debug.Log($"z: {transform.rotation.z}");

            obj.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
            _shootTimer = 0.5f;
        }
    }

    public void Action()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction);
        Debug.DrawRay(transform.position, Direction);
        if (hit.collider != null && hit.collider.tag.ToLower() == "door")
        {
            var doorOpen = hit.collider.GetComponent<DoorOpen>();
            doorOpen.RoomClosed.SetActive(false);
            doorOpen.RoomOpened.SetActive(true);
            doorOpen.gameObject.SetActive(false);
        }
    }

}
