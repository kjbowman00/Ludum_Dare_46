using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Interactable
{
    private ParticleSystem particleSystem;
    private PipeManager pipeManager;
    private bool bursted;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        pipeManager = GetComponentInParent<PipeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void burst()
    {
        //Turn red right now to show that it's bursted
        bursted = true;
        particleSystem.Play();
    }

    private void fixPipe()
    {
        bursted = false;
        pipeManager.repairedPipe();
        particleSystem.Stop();
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
			}
			return Item.None;
		}
		return Item.Current;
    }
}
