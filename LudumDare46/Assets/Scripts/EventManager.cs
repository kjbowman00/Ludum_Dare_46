using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void _PipeBurst();
    public static event _PipeBurst PipeBurst;
	
	public delegate void _LaserFire(float startAngle, float endAngle, float time, Vector3 startingPoint);
	public static event _LaserFire LaserFire;
	
	public delegate void _GetHit();
	public static event _GetHit GetHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public static void getHit()
	{
		Debug.Log("Got hit... Loser.");
		GetHit();
	}

    //Purely for debug purposes. These aren't used in real gameplay
    public void buttonClicked(string name)
    {
        switch(name)
        {
            case "PipeBurst":
                Debug.Log("PipeBurst event activated");
                PipeBurst();
                break;
			case "Laser Baby":
				Debug.Log("Laser has been fired");
				LaserFire(0f, -90f, 5f, Vector3.zero);
				break;
			case "Get Hit":
				Debug.Log("Get hit nerd");
				GetHit();
				break;
            default:
                Debug.Log("Unkown Button Name: " + name);
                break;
        }
    }
}
