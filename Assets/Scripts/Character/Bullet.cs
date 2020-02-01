using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float rotation;
    public Vector2 charFace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        if (other.gameObject.layer == 8)
        {
            Destroy(this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.layer == 8)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rotation = transform.localRotation.z;
        if (charFace == Vector2.left)
            transform.position = new Vector2(transform.position.x - 10  * Time.fixedDeltaTime, transform.position.y);
        else if (charFace == Vector2.down)
            transform.position = new Vector2(transform.position.x, transform.position.y - 10 * Time.fixedDeltaTime);
        else if (charFace == Vector2.up)
            transform.position = new Vector2(transform.position.x, transform.position.y + 10 * Time.fixedDeltaTime);
        else
            transform.position = new Vector2(transform.position.x + 10 * Time.fixedDeltaTime, transform.position.y);
    }
}
