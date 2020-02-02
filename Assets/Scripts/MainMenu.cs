using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject Credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToCredits()
    {
        StartMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void GoToStartMenu()
    {
        StartMenu.SetActive(true);
        Credits.SetActive(false);
    }
}
