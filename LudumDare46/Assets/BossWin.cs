using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWin : MonoBehaviour
{
    private AudioSource myAudio;
    float timer = 0;
    float pitchTime = 9f;
    float endTime = 16f;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= pitchTime) myAudio.pitch = 0.7f;
        if (timer >= endTime)
        {
            myAudio.pitch = 1f;
            SceneChanger.instance.toMenu(4);
        }
    }
}
