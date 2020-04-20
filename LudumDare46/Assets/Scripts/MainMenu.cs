using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressPlay()
    {
        SceneChanger.instance.LoadIntro();
    }

    public void pressQuit()
    {
        Application.Quit();
    }

    public void volumeChange()
    {
        AudioListener.volume = slider.value;
    }
}
