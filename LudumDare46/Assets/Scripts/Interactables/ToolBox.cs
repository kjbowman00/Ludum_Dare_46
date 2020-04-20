using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBox : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override Item interact(Item playerItem)
    {
        Debug.Log("TOOLS");
		EventManager.placeMop();
        return Item.Tools;
    }
}
