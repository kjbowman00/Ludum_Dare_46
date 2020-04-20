using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Interactable
{
    private PipeManager pipeManager;
    private bool bursted;
    // Start is called before the first frame update
    void Start()
    {
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
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void fixPipe()
    {
        bursted = false;
        pipeManager.repairedPipe();
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public bool isBurst()
    {
        return bursted;
    }

    public override Item interact(Item playerItem)
    {
        Debug.Log("Pipe interaction");
        if (playerItem == Item.Tools)
        {
            fixPipe();
        }
        return Item.None;
    }
}
