using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    CharacterMovement charMovement;
    public GameObject bullet;
    public float bulletLifeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        charMovement = gameObject.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (charMovement.haveGun && Input.GetButtonDown("Fire1_" + charMovement.playerNumber))
        {
            var bulletCreated = Instantiate(bullet, transform.position, transform.rotation);
            bulletCreated.GetComponent<Bullet>().charFace = charMovement.charFace;
            Destroy(bulletCreated, bulletLifeTime);
        }
    }
}
