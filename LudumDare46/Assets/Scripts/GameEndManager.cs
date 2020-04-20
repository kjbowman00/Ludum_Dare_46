using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    public GameObject clockHand;
    public float TOTAL_TIME_NEEDED;
    private float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        float percentage = timePassed / TOTAL_TIME_NEEDED;
        clockHand.transform.localRotation = Quaternion.Euler(0, 0, percentage * -360);
        if (timePassed > TOTAL_TIME_NEEDED)
        {
            //WIN!!!
        }
    }

    //Lose the game
    public void outOfHealth()
    {
        //Flash black screen
        //Scene with everything but you can't move
        //Just an animation at that poitn
        //Boss comes in and smashes you from anger
    }

    public float getPercentageTime()
    {
        return timePassed / TOTAL_TIME_NEEDED;
    }
}
