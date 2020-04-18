using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTools : MonoBehaviour
{
    private Canvas cv;

    // Start is called before the first frame update
    void Start()
    {
        cv = GetComponent<Canvas>();
        cv.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.G))
        {
            cv.enabled = !cv.enabled;
        }
    }
}
