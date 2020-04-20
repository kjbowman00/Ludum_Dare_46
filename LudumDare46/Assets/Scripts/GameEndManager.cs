using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    public SpriteRenderer[] babySprites;
    public GameObject clockHand;
    public float TOTAL_TIME_NEEDED;
    private float timePassed;

    private float updateVisualsClock = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateVisualsClock += Time.deltaTime;
        timePassed += Time.deltaTime;
        if (updateVisualsClock > 3f)
        {
            float percentage = timePassed / TOTAL_TIME_NEEDED;
            clockHand.transform.localRotation = Quaternion.Euler(0, 0, percentage * -360);
            float invertedP = 1 - percentage;
            updateVisualsClock = 0;
            for (int i = 0; i < babySprites.Length; i++)
            {
                babySprites[i].color = new Color(1, Mathf.Lerp(0.5f, 1, invertedP), Mathf.Lerp(0.5f, 1, invertedP));
            }
        }
      
        if (timePassed > TOTAL_TIME_NEEDED)
        {
            //WIN!!!
            winGame();
        }
    }

    //Lose the game
    public void outOfHealth()
    {
        MusicTime.instance.stopMusic();
        SceneChanger.instance.loseGame();
    }

    public void winGame()
    {
        MusicTime.instance.stopMusic();
        SceneChanger.instance.winGame();
    }

    public float getPercentageTime()
    {
        return timePassed / TOTAL_TIME_NEEDED;
    }
}
