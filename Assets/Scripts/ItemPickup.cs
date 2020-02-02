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
        var level = LevelController.Instance;
        var ui = UIController.Instance;
        if (other.tag.ToUpper() == "PLAYER1" || other.tag.ToUpper() == "PLAYER2" || other.tag.ToUpper() == "PLAYER")
        {
            switch (this.tag)
            {
                case "Parts":
                    level.Parts++;
                    UIController.Instance.Parts.text = $"Partes: {level.Parts} / {LevelController.Instance.RequiredParts}";
                    AudioManager.Instance.PlaySfx(3);
                    Destroy(gameObject);
                    break;
                case "Fuel":
                    level.Fuel++;
                    UIController.Instance.Fuel.text = $"Gasolina: {level.Fuel} / {LevelController.Instance.RequiredFuel}";
                    AudioManager.Instance.PlaySfx(3);
                    Destroy(gameObject);
                    break;
                case "Tools":
                    level.Tools++;
                    UIController.Instance.Tools.text = $"Ferramentas: {level.Tools} / {LevelController.Instance.RequiredTools}";
                    AudioManager.Instance.PlaySfx(4);
                    Destroy(gameObject);
                    break;
            }
        }
    }

}
