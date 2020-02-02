using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public AudioSource[] Sfx;

    public AudioSource GameLoop;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameLoop.Stop();
        GameLoop.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySfx(int sfxToPlay)
    {
        Sfx[sfxToPlay].Stop();
        Sfx[sfxToPlay].Play();
    }
}
