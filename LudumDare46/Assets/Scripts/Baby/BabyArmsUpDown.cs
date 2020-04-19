using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyArmsUpDown : MonoBehaviour
{
    public float shiftAmount;
    public float speed;
    private float halfShift;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        halfShift = shiftAmount / 2;
    }

    // Update is called once per frame
    void Update()
    {
        float ping = Mathf.PingPong(Time.time*speed, shiftAmount);
        transform.position = new Vector3(transform.position.x, ping - halfShift + startY, transform.position.z);
    }
}
