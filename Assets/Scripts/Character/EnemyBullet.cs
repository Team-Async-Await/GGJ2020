using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed;
    public Vector3 Direction;
    public PlayerController player;

    void Start()
    {
        Direction = player.transform.position - transform.position;
        Direction.Normalize();

    }

    void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.ToUpper() == "PLAYER1" || collision.tag.ToUpper() == "PLAYER2")
        {
            PlayerHealthController.Instance.DamagePlayer(collision.gameObject);
            AudioManager.Instance.PlaySfx(9);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
