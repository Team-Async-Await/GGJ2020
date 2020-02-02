using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public Slider HealthSliderP1;
    public Text HealthTextP1;
    public Slider HealthSliderP2;
    public Text HealthTextP2;
    public Text Parts;
    public Text Fuel;
    public Text Tools;

    private void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        Parts.text = $"Partes: 0 / " + LevelController.Instance.RequiredParts;
        Fuel.text = $"Gasolina: 0 / " + LevelController.Instance.RequiredFuel;
        Tools.text = $"Ferramentas: 0 / " + LevelController.Instance.RequiredTools;
    }

    void Update()
    {

    }
}
