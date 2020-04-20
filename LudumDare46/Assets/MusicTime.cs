using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTime : MonoBehaviour
{
    private AudioSource music;
    public static MusicTime instance;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        instance = this;
        DontDestroyOnLoad(this.gameObject);       
    }

    public void stopMusic()
    {
        music.Stop();
    }
    public void playMusic()
    {
        music.Play();
    }
}
