using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public Slider HealthSlider;
    public Text HealthText;
    public GameObject DeathScreen;
    public Text Parts;
    public Text Fuel;
    public Text Tools;

    private void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        Parts.text = $"Partes: 0 / 10";
        Fuel.text = $"Gasolina: 0 / 10";
        Tools.text = $"Ferramentas: 0 / 10";
    }

    void Update()
    {

    }
}
