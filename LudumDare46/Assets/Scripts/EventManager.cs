﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameEndManager clock;
    private float[] probs;
    private float[] initialProbs;
    private float[] maxProbs;

    private float timeCounter;

    public delegate void _PipeBurst();
    public static event _PipeBurst PipeBurst;
	
	public delegate void _LaserFire(float startAngle, float endAngle, float time, Vector3 startingPoint);
	public static event _LaserFire LaserFire;
	
	public delegate void _GetHit();
	public static event _GetHit GetHit;

    public delegate void _SpawnMilk();
    public static event _SpawnMilk SpawnMilk;
	
	public delegate void _PlaceMop();
	public static event _PlaceMop PlaceMop;
	
    // Start is called before the first frame update
    void Start()
    {
        probs = new float[3];
        probs[0] = getProb(4); //Pipe Burst
        probs[1] = getProb(1); //Laser eyes
        probs[2] = getProb(1); //Milk spurt
        initialProbs = new float[3];
        probs.CopyTo(initialProbs, 0);
        maxProbs = new float[3];
        maxProbs[0] = getProb(10);
        maxProbs[1] = getProb(3);
        maxProbs[2] = getProb(8);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < probs.Length; i++)
        {
            float r = Random.Range(0f, 1f);
            if (r < probs[i])
            {
                //Make event happen
                switch(i)
                {
                    case 0:
                        Debug.Log("Pipe Burst");
                        PipeBurst();
                        break;
                    case 1:
                        Debug.Log("Laser has been fired");
                        LaserFire(0f, -90f, 5f, Vector3.zero);
                        break;
                    case 2:
                        Debug.Log("Milk Spilt");
                        break;
                    default:
                        break;
                }
            }
        }

        timeCounter += Time.fixedDeltaTime;
        if (timeCounter > 5)
        {
            float percentage = clock.getPercentageTime();
            for (int i = 0; i < probs.Length; i++)
            {
                probs[i] = percentage * (maxProbs[i] - initialProbs[i]) + initialProbs[i];
            }
        }

    }

	public static void placeMop()
	{
		Debug.Log("Replaced mop");
		PlaceMop();
	}
	
	public static void getHit()
	{
		Debug.Log("Got hit... Loser.");
		GetHit();
	}

    //Purely for debug purposes. These aren't used in real gameplay
    public void buttonClicked(string name)
    {
        switch(name)
        {
            case "PipeBurst":
                Debug.Log("PipeBurst event activated");
                PipeBurst();
                break;
			case "Laser Baby":
				Debug.Log("Laser has been fired");
				LaserFire(0f, -90f, 5f, Vector3.zero);
				break;
			case "Get Hit":
				Debug.Log("Get hit nerd");
				GetHit();
				break;
            default:
                Debug.Log("Unkown Button Name: " + name);
                break;
        }
    }

    private float getProb(float times)
    {
        return (times/60f) * Time.fixedDeltaTime;
    }

}
