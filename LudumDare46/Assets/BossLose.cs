using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLose : MonoBehaviour
{
    public static bool begin = false;
    public ParticleSystem blood;
    public GameObject jumpPos1;
    public GameObject jumpPos2;
    private Vector3 basePos;
    public GameObject agSound;
    public GameObject mySonSound;
    public GameObject loseTExt;
    private SpriteRenderer bossImage;
    int count = 0;
    float[] eventTimes;
    float timer = 0;

    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        basePos = transform.position;
        bossImage = GetComponent<SpriteRenderer>();
        eventTimes = new float[5];
        eventTimes[0] = 2;
        eventTimes[1] = 2;
        eventTimes[2] = 0.5f;
        eventTimes[3] = 0.5f;
        eventTimes[4] = 500;
    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            timer += Time.deltaTime;
            if (timer > eventTimes[count])
            {
                timer = 0;
                count++;
            }
            switch (count)
            {
                case 0:
                    //Spawn text box saying WHAT YOU DO
                    //play sound for it
                    if (!loseTExt.activeSelf) loseTExt.SetActive(true);
                    if (!mySonSound.activeSelf) mySonSound.SetActive(true);
                    break;
                case 1:
                    if (loseTExt.activeSelf) loseTExt.SetActive(false);
                    //AGGGGHHHH sound
                    //Scale boss up based on percentage
                    //Turn red
                    if (!agSound.activeSelf) agSound.SetActive(true);
                    float percentage = timer / eventTimes[count];
                    bossImage.color = new Color(1, 1 - percentage, 1 - percentage);
                    transform.localScale = new Vector3(Mathf.Lerp(0.5f, 3, percentage), Mathf.Lerp(0.5f, 3, percentage), 1);
                    break;
                case 2:
                    //First jump
                    percentage = timer / eventTimes[count];
                    transform.position = Vector3.Lerp(basePos, jumpPos1.transform.position, percentage);
                    break;
                case 3:
                    //Second jump and splat
                    percentage = timer / eventTimes[count];
                    transform.position = Vector3.Lerp(jumpPos1.transform.position, jumpPos2.transform.position, percentage);
                    if (percentage >= 0.5)
                    {
                        //Play particles
                        if (!blood.isPlaying) blood.Play();
                        //Play sound

                    }
                    break;
                case 4:
                    //Go to main menu
                    if (!done)
                    {
                        begin = false;
                        done = true;
                        SceneChanger.instance.toMenu(3);
                    }
                    break;
            }
        }
    }
}
