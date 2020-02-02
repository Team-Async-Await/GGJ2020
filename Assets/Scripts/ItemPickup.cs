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
                    UIController.Instance.Parts.text = $"Partes: {level.Parts} / 10";
                    AudioManager.Instance.PlaySfx(3);
                    Destroy(gameObject);
                    break;
                case "Fuel":
                    level.Fuel++;
                    UIController.Instance.Fuel.text = $"Gasolina: {level.Fuel} / 10";
                    AudioManager.Instance.PlaySfx(3);
                    Destroy(gameObject);
                    break;
                case "Tools":
                    level.Tools++;
                    UIController.Instance.Tools.text = $"Ferramentas: {level.Tools} / 10";
                    AudioManager.Instance.PlaySfx(4);
                    Destroy(gameObject);
                    break;
            }
        }
    }

}
