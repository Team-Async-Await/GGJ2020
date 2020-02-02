using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int Parts;
    public int Fuel;
    public int Tools;
    public int RequiredParts;
    public int RequiredFuel;
    public int RequiredTools;
    public static PlayerController Player1;
    public static PlayerController Player2;
    public static LevelController Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
