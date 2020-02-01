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
    public GameObject Parts;
    public GameObject Fuel;
    public GameObject Tools;

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
        if (PlayerController.Instance == null)
            return;

        var distance = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        _moveDirection = PlayerController.Instance.transform.position - transform.position;
        _moveDirection.Normalize();
        if (distance <= rangeToChase)
        {
            _body.velocity = Vector3.zero;
            FireCounter -= Time.deltaTime;
            if (FireCounter <= 0)
            {
                FireCounter = FireRate;
                AudioManager.Instance.PlaySfx(6);
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

            var turn = _moveDirection * MoveSpeed;
            Rotate(turn);

            if (distance < rangeToChase / 4)
            {
                _body.velocity = _moveDirection * MoveSpeed;
                Rotate(_body.velocity);
            }
        }
    }

    public void DamageEnemy(int damage)
    {
        _health -= damage;
        Instantiate(BloodEffect, transform.position, transform.rotation);
        AudioManager.Instance.PlaySfx(2);

        if (_health <= 0)
        {
            Instantiate(_blood, transform.position, transform.rotation);
            
            var range = Random.Range(0, 100);
            if (range > -1)
            {
                range = Random.Range(0,3);
                switch (range)
                {
                    case 0:
                        Instantiate(Parts, transform.position, transform.rotation);
                        break;
                    case 1:
                        Instantiate(Fuel, transform.position, transform.rotation);
                        break;
                    case 2:
                        Instantiate(Tools, transform.position, transform.rotation);
                        break;
                }
            }
            AudioManager.Instance.PlaySfx(1);
            Destroy(gameObject);
        }
    }

    private void Rotate(Vector3 rotate)
    {
        if (Mathf.Abs(rotate.x) > Mathf.Abs(rotate.y))
        {
            if (rotate.x > 0)
                transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            else if (rotate.x < 0)
                transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            else if (rotate.y > 0)
                transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            else if (rotate.y < 00)
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
        }
        else
        {
            if (rotate.y > 0)
                transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            else if (rotate.y < 0)
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            else if (rotate.x > 0)
                transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            else if (rotate.x < 0)
                transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
    }
}
