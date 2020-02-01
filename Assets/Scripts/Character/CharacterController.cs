using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    private Vector2 _moveInput;

    public Sprite Idle;
    public Sprite Gun;

    public Rigidbody2D Body;
    public SpriteRenderer Sprite;

    public bool haveGun = false;

    private void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal_P2");
        _moveInput.y = Input.GetAxisRaw("Vertical_P2");

        Body.velocity = _moveInput * _moveSpeed;

        if (haveGun)
        {
            Sprite.sprite = Gun;
        }
        else
        {
            Sprite.sprite = Idle;
        }

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
