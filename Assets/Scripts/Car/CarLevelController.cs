using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLevelController : MonoBehaviour
{
    public float startPosition;
    public float breakPosition;
    public float endPosition;
    public float verticalPosition;
    public float carSpeed = 7f;

    public bool carFixed = false;
    public GameObject carSmoke;
    public GameObject player1;
    public GameObject player2;

    public bool gameStarted = false;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        carSmoke.SetActive(false);
        transform.position = new Vector2(startPosition, verticalPosition);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (
            (other.tag.ToUpper() == "PLAYER1" && Input.GetButtonDown("Fire2_P1"))
            || ((other.tag.ToUpper() == "PLAYER2" && Input.GetButtonDown("Fire2_P2")))
            )
        {
            carFixed = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!carFixed)
        {
            if (body.position.x >= breakPosition)
            {
                body.MovePosition(new Vector2(body.position.x + -1 * carSpeed * Time.fixedDeltaTime, body.position.y));
            }
            else
            {
                carSmoke.SetActive(true);
                //carSmoke.GetComponent<SpriteRenderer>().sortingLayerName = "Wall";
                if (!gameStarted)
                {
                    gameStarted = true;
                    Invoke("StartGame", 1f);
                }
            }
        }
        else
        {
            carSmoke.SetActive(false);
            if (body.position.x >= endPosition)
                body.MovePosition(new Vector2(body.position.x + -1 * carSpeed * Time.fixedDeltaTime, body.position.y));
        }
    }
    void StartGame()
    {
        var P1Position = new Vector3(transform.position.x, transform.position.y - 1);
        var P2Position = new Vector3(transform.position.x, transform.position.y + 1);
        //Instantiate(player1, P1Position, transform.rotation);
        //Instantiate(player2, P2Position, transform.rotation);
        player1.transform.position = P1Position;
        player1.transform.rotation = transform.rotation;
        player2.transform.position = P2Position;
        player2.transform.rotation = transform.rotation;
    }
}
