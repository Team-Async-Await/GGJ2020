using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneMenu : MonoBehaviour
{
   public void Load(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
