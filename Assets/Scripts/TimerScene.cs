using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScene : MonoBehaviour
{
    public string SceneName;
    public float SecondsToScene = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoToScene", SecondsToScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }
}
