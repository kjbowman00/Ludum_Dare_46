using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : Interactable
{
	
	private bool pickedUp = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void OnEnable()
	{
		EventManager.PlaceMop += placeMop;
	}
	
	void OnDisable()
	{
		EventManager.PlaceMop -= placeMop;
	}

    // Update is called once per frame
    void Update()
    {
		// haha this is SO efficient for framerate! yay!!!
		if (pickedUp)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
    }
	
	void placeMop()
	{
		pickedUp = false;
	}
	
	
    public override Item interact(Item playerItem)
    {
        Debug.Log("MOP");
		pickedUp = true;
        return Item.Mop;
    }
}
