using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEye : MonoBehaviour
{
	
	private LineRenderer render;
	
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<LineRenderer>();
		render.SetPosition(0, new Vector3(0f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
		render.SetPosition(1, new Vector3(1f, -1f, 0f)); 
    }
}
