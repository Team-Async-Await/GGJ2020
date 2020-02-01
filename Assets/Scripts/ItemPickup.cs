using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = PlayerController.Instance;
        var ui = UIController.Instance;
        if (other.tag == "Player")
        {
            switch (this.tag)
            {
                case "Parts":
                    player.Parts++;
                    UIController.Instance.Parts.text = $"Partes: {player.Parts} / 10";
                    Destroy(gameObject);
                    break;
                case "Fuel":
                    player.Fuel++;
                    UIController.Instance.Fuel.text = $"Gasolina: {player.Fuel} / 10";
                    Destroy(gameObject);
                    break;
                case "Tools":
                    player.Tools++;
                    UIController.Instance.Tools.text = $"Ferramentas: {player.Tools} / 10";
                    Destroy(gameObject);
                    break;
            }
        }
    }

}
