using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private bool bursted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void burst()
    {
        //Turn red right now to show that it's bursted
        bursted = true;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void fixPipe()
    {

    }

    public bool isBurst()
    {
        return bursted;
    }
}
