using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed;
    public Vector3 Direction;


    void Start()
    {
        Direction = PlayerController.Instance.transform.position - transform.position;
        Direction.Normalize();

    }

    void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
