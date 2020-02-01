using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D _body;

    public float rangeToChase;
    private Vector3 _moveDirection;

    [SerializeField]
    private GameObject _blood;
    public GameObject BloodEffect;

    public bool shouldShoot;

    public GameObject bullet;
    public Transform FirePoint;
    public float FireRate;
    public float FireCounter;

    private int _health = 50;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <= rangeToChase)
        {
            _moveDirection = PlayerController.Instance.transform.position - transform.position;
            if (shouldShoot)
            {
                FireCounter -= Time.deltaTime;
                if (FireCounter <= 0)
                {
                    FireCounter = FireRate;

                    var obj = Instantiate(bullet, FirePoint.transform.position, FirePoint.transform.rotation);
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
                }
            }
        }

        _moveDirection.Normalize();
        _body.velocity = _moveDirection * MoveSpeed;

        if (Mathf.Abs(_body.velocity.x) > Mathf.Abs(_body.velocity.y))
        {
            if (_body.velocity.x > 0)
                transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            else if (_body.velocity.x < 0)
                transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            else if (_body.velocity.y > 0)
                transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            else if (_body.velocity.y < 00)
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
        }
        else
        {
            if (_body.velocity.y > 0)
                transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            else if (_body.velocity.y < 00)
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            else if (_body.velocity.x > 0)
                transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            else if (_body.velocity.x < 0)
                transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }

        

    }

    public void DamageEnemy(int damage)
    {
        _health -= damage;
        Instantiate(BloodEffect, transform.position, transform.rotation);

        if (_health <= 0)
        {
            Instantiate(_blood, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
