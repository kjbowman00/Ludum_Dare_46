using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBox : Interactable
{
	
	private bool pickedUp = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnEnable()
	{
		EventManager.PlaceToolbox += placeToolbox;
	}
	
	void OnDisable()
	{
		EventManager.PlaceToolbox -= placeToolbox;
	}
	
    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
    }
	
	void placeToolbox()
	{
		pickedUp = false;
	}
	
    public override Item interact(Item playerItem)
    {
        Debug.Log("TOOLS");
		EventManager.placeMop();
		pickedUp = true;
        return Item.Tools;
    }
}
