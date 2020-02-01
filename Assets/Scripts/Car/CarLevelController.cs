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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!carFixed)
        {
            if (body.position.x >= breakPosition)
            {
                body.MovePosition(new Vector2(body.position.x + -1 * carSpeed * Time.fixedDeltaTime, body.position.y));
            } else
            {
                carSmoke.SetActive(true);
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
        var P1Position = new Vector3(transform.position.x , transform.position.y - 1);
        var P2Position = new Vector3(transform.position.x , transform.position.y + 1);
        Instantiate(player1, P1Position, transform.rotation);
        Instantiate(player2, P2Position, transform.rotation);
    }
}
