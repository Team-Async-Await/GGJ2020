using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarLevelController : MonoBehaviour
{
    public float startPosition;
    public float breakPosition;
    public float endPosition;
    public float horizontalPosition;
    public float carSpeed = 12f;

    public bool carFixed = false;
    public GameObject carSmoke;
    public GameObject player1;
    public GameObject player2;


    public GameObject CameraP1;
    public GameObject CameraP2;
    public GameObject CameraCinematic;


    public GameObject StartPosition;
    public GameObject BrakePosition;
    public GameObject EndPosition;

    public bool gameStarted = false;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        horizontalPosition = StartPosition.transform.position.x;
        startPosition = StartPosition.transform.position.y;
        breakPosition = BrakePosition.transform.position.y;
        endPosition = EndPosition.transform.position.y;

        body = GetComponent<Rigidbody2D>();
        carSmoke.SetActive(false);
        transform.position = new Vector2(horizontalPosition, startPosition);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (
            (other.tag.ToUpper() == "PLAYER1" && Input.GetButtonDown("Fire2_P1"))
            || ((other.tag.ToUpper() == "PLAYER2" && Input.GetButtonDown("Fire2_P2")))
            )
        {
            if ((LevelController.Instance.RequiredParts <= LevelController.Instance.Parts)
                && (LevelController.Instance.RequiredFuel <= LevelController.Instance.Fuel)
                && (LevelController.Instance.RequiredTools <= LevelController.Instance.Tools)
                )
            {
                carFixed = true;
                CameraCinematic.SetActive(true);
                CameraP1.SetActive(false);
                player1.SetActive(false);
                if (player2 != null)
                {
                    CameraP2.SetActive(false);
                    player2.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!carFixed)
        {
            if (body.position.y <= breakPosition)
            {
                body.MovePosition(new Vector2(body.position.x, body.position.y + carSpeed * Time.fixedDeltaTime));
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
            if (body.position.y <= endPosition)
                body.MovePosition(new Vector2(body.position.x, body.position.y + carSpeed * Time.fixedDeltaTime));
            else
            {
                if (player2 == null)
                    SceneManager.LoadScene("EndStory_1P");
                else
                    SceneManager.LoadScene("EndStory_2P");
            }
        }
    }
    void StartGame()
    {
        AudioManager.Instance.GameLoop.Play();
        AudioManager.Instance.GameLoop.loop = true;
        var P1Position = new Vector3(transform.position.x - 1, transform.position.y);
        var P2Position = new Vector3(transform.position.x + 1, transform.position.y);
        player1.transform.position = P1Position;
        player1.transform.rotation = transform.rotation;

        CameraCinematic.SetActive(false);
        CameraP1.SetActive(true);        
        if (player2 != null)
        {
            CameraP2.SetActive(true);
            player2.transform.position = P2Position;
            player2.transform.rotation = transform.rotation;
        }
    }
}
