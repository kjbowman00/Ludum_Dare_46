using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void OnEnable()
	{
		EventManager.LaserFire += laserFire;
	}
	
	void OnDisable()
	{
		EventManager.LaserFire -= laserFire;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void laserFire(float startAngle, float endAngle, float time, Vector3 startingPoint)
	{
		var laser = Resources.Load<Object>("Laser") as GameObject;
		var createdLaser = Object.Instantiate(laser, Vector3.zero, Quaternion.identity);
		createdLaser.GetComponent<LaserEye>().setLaserParams(startAngle, endAngle, time, startingPoint);
	}
}
