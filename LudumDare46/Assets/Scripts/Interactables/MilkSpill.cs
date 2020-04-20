using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSpill : Interactable
{
	
	private bool toDestroy = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toDestroy)
		{
			Destroy(gameObject);
		}
    }
	
	private void cleanMilk()
	{
		toDestroy = true;
	}
	
    public override Item interact(Item playerItem)
    {
        if (playerItem == Item.Mop)
        {
			EventManager.placeMop();
            cleanMilk();
        }
        return Item.Current;
    }
}
