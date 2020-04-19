using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBaby : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void spawnMilk(float x, float y)
	{
		var milk = Resources.Load<Object>("Milk Spill") as GameObject;
		var createdMilk = Object.Instantiate(milk, new Vector3(x, y, 0), Quaternion.identity);
		Debug.Log("Created " + createdMilk.name + " at " + x + ", " + y + ".");
	}
}
