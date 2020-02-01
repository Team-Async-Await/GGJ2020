using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float Speed = 7.5f;
    public GameObject ImpactEffect;
    private Rigidbody2D _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _body.velocity = transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        collision.GetComponent<EnemyController>()?.DamageEnemy(25);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
