using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump : Interactable
{
    private AudioSource audio;
    private Animator animator;
    public float pumpDuration;
    public float randomness;

    private bool pumpOn;
    private float timePassed;
    private float timeNeeded;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
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
                animator.SetBool("PumpOn", false);
            }
        } 
    }

    public override Item interact(Item playerItem)
    {
        if (!pumpOn)
        {
            pumpOn = true;
            animator.SetBool("PumpOn", true);
        }

        return Item.Current;
    }

    //Return 1 if running, 0 if not
    public int pumpStatus()
    {
        return pumpOn ? 1 : 0;
    }

    public void playSound()
    {
        audio.Play();
    }
}
