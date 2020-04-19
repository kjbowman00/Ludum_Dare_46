using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
	
	private bool isGrounded = true;
	private float jumpTime = 0;

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
		
		jumpTime += Time.deltaTime;		
		if (Input.GetKey("w") && isGrounded && jumpTime >= .34)
		{
			rb.velocity = new Vector2(xVel, jumpForce);
			jumpTime = 0;
		}
		
    }
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "floor")
		{
			isGrounded = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "floor")
		{
			isGrounded = false;
		}
	}
	
}
