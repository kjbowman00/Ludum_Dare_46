using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBaby : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.SpawnMilk += milkTime;
    }

    private void OnDisable()
    {
        EventManager.SpawnMilk -= milkTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
    public void milkTime()
    {
        float location = Random.Range(-7.5f, 7.5f);
        spawnMilk(location, -4.2f);
    }

	void spawnMilk(float x, float y)
	{
		var milk = Resources.Load<Object>("Milk Spill") as GameObject;
		var createdMilk = Object.Instantiate(milk, new Vector3(x, y, 0), Quaternion.identity);
		Debug.Log("Created " + createdMilk.name + " at " + x + ", " + y + ".");
	}
}
