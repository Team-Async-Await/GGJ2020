using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject RoomClosed;
    public GameObject RoomOpened;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (
            (other.tag.ToUpper() == "PLAYER1" && Input.GetButtonDown("Fire2_P1"))
            || ((other.tag.ToUpper() == "PLAYER2" && Input.GetButtonDown("Fire2_P2")))
            )
        {
            RoomClosed.SetActive(false);
            RoomOpened.SetActive(true);
            this.enabled = false;
        }
    }
}
