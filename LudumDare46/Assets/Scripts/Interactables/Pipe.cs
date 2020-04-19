using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Interactable
{
    private bool bursted;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public bool isBurst()
    {
        return bursted;
    }

    public override Item interact(Item playerItem)
    {
        if (playerItem == Item.Tools)
        {
            fixPipe();
        }
        return Item.None;
    }
}
