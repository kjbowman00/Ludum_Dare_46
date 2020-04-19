using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEye : MonoBehaviour
{
	
	private LineRenderer render;
	private Physics2D phys = new Physics2D();
	
	private Vector3 start;
	private Vector2 direction;
	
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<LineRenderer>();
		render.SetPosition(0, start);
    }

    // Update is called once per frame
    void Update()
    {
		// Vector2 start = new Vector2(0.4f, 2.37f);
		// Vector2 direction = new Vector2(1f, -1f);
		
		Vector2 raycastStart = start;
		
		RaycastHit2D hit = Physics2D.Raycast(raycastStart, direction);
		render.SetPosition(1, hit.point - raycastStart); 
    }
	
	public void setLaserParams(float angle, Vector3 startingPoint)
	{
		angle = angle / (float) System.Math.PI * 180f;
		direction = new Vector2((float) System.Math.Cos(angle), (float) System.Math.Sin(angle));
		start = startingPoint;
	}
}
