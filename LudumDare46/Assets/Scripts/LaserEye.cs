using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEye : MonoBehaviour
{
	
	private LineRenderer render;
	private Physics2D phys = new Physics2D();
	
	private Vector2 start;
	private Vector2 currentDirection;
	private float currentAngle;
	private float deltaAngle;
	private float time;
	private bool activated = false;
	
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<LineRenderer>();
		render.SetPosition(0, start);
    }

    // Update is called once per frame
    void Update()
    {
		if (activated)
		{
			gameObject.GetComponent<Renderer>().enabled = true;
			
			// Moves the laser deltaAngle towards target angle every tick
			time -= Time.deltaTime;
			RaycastHit2D hit = Physics2D.Raycast(start, currentDirection);
			render.SetPosition(1, hit.point);
			currentAngle += deltaAngle * Time.deltaTime * 2;
			currentDirection += new Vector2((float) System.Math.Cos(currentAngle), (float) System.Math.Sin(currentAngle));
			
			// Player hit detection
			if (hit.collider.gameObject.tag == "Player")
			{
				EventManager.getHit();
			}
			
			// Disables the laser once it has done a full sweep
			if (time < 0)
			{
				//gameObject.GetComponent<Renderer>().enabled = false;
				//activated = false;
				//render.SetPosition(1, start);
				Destroy(gameObject);
			}
		}
    }
	
	public void setLaserParams(float startAngle, float endAngle, float time, Vector3 start)
	{
		startAngle = startAngle * (float) System.Math.PI / 180f;
		this.currentDirection = new Vector2((float) System.Math.Cos(startAngle), (float) System.Math.Sin(startAngle));
		endAngle = endAngle * (float) System.Math.PI / 180f;
		//endDirection = new Vector2((float) System.Math.Cos(endAngle), (float) System.Math.Sin(endAngle));
		deltaAngle = (endAngle - startAngle) / time;
		this.currentAngle = startAngle;
		this.start = start;
		this.time = time;
		Debug.Log(endAngle + " " + startAngle + " " + deltaAngle);
		activated = true;
	}
}
