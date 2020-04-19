using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump : Interactable
{

    public float pumpDuration;
    public float randomness;
    public int pumpFixNeeded;

    private int pumpFixPassed;

    private bool pumpOn;
    private float timePassed;
    private float timeNeeded;
    // Start is called before the first frame update
    void Start()
    {
        pumpOn = true;
        timePassed = 0;
        timeNeeded = pumpDuration + Random.Range(0, randomness);
    }

    // Update is called once per frame
    void Update()
    {
        if (pumpOn)
        {
            if (timePassed < timeNeeded)
            {
                timePassed += Time.deltaTime;
            }
            else
            {
                timePassed = 0;
                timeNeeded = pumpDuration + Random.Range(0, randomness);
                pumpOn = false;
                GetComponent<SpriteRenderer>().color = Color.red; //Temporary until we animate
            }
        } 
        else
        {
            if (pumpFixPassed >= pumpFixNeeded)
            {
                //Pump is now fixed
                pumpOn = true;
                pumpFixPassed = 0;
                GetComponent<SpriteRenderer>().color = Color.white; //Temporary until we animate
            }
        }
    }

    public override Item interact()
    {
        if (!pumpOn)
        {
            pumpFixPassed++;
        }

        return Item.None;
    }
}
