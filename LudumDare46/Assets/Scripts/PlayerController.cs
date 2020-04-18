using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;


    private bool a, d;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xVel = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(xVel, rb.velocity.y);
        //transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
    }
}
