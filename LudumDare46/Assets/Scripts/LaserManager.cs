using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
	
	public LaserEye[] laserEyes;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void OnEnable()
	{
		laserEyes = GetComponentsInChildren<LaserEye>();
		EventManager.LaserFire += laserEyes[0].setLaserParams;
	}
	
	void OnDisable()
	{
		EventManager.LaserFire -= laserEyes[0].setLaserParams;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
