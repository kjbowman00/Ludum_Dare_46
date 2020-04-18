using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void _PipeBurst();
    public static event _PipeBurst PipeBurst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            default:
                Debug.Log("Unkown Button Name: " + name);
                break;
        }
    }
}
