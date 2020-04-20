using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Interactable
{
    private AudioSource hammerSound;
    public Pump myRelevantPump;
    private Animator myAnimator;
    private ParticleSystem myParticleSystem;
    private PipeManager pipeManager;
    private bool bursted;
    // Start is called before the first frame update
    void Start()
    {
        hammerSound = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
        myParticleSystem = GetComponent<ParticleSystem>();
        pipeManager = GetComponentInParent<PipeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void burst()
    {
        if (myRelevantPump.pumpStatus() == 1)
        {
            //Pump is on, animate
            myParticleSystem.Play();
        }
        bursted = true;
    }

    private void fixPipe()
    {
        bursted = false;
        pipeManager.repairedPipe();
        myParticleSystem.Stop();
    }

    public bool isBurst()
    {
        return bursted;
    }

    public override Item interact(Item playerItem)
    {
		if (bursted)
		{
			if (playerItem == Item.Tools)
			{
				EventManager.placeToolbox();
				fixPipe();
                hammerSound.Play();
				return Item.Current;
			}
		}
		return Item.Current;
    }

    public void pumpChange(bool on)
    {
        if (on)
        {
            myAnimator.SetBool("PumpOn", true);
            if (bursted) myParticleSystem.Play();
        }
        else
        {
            myAnimator.SetBool("PumpOn", false);
            myParticleSystem.Stop();
        }
    }
}
