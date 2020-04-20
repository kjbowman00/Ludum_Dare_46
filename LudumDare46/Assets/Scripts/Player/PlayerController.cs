using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
	public float hitStun;

    private Rigidbody2D rb;
	
	private bool isGrounded = true;
	private bool canMove = true;
	private int milkCounter = 0;
	private float jumpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void OnEnable()
	{
		EventManager.GetHit += getHit;
	}
	
	void OnDisable()
	{
		EventManager.GetHit -= getHit;
	}

    // Update is called once per frame
    void Update()
    {
		if (canMove)
		{
			float xVel = Input.GetAxis("Horizontal") * speed;
			if (milkCounter > 0) { xVel = xVel / 5; }
			rb.velocity = new Vector2(xVel, rb.velocity.y);
			//transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
			
			jumpTime += Time.deltaTime;		
			if (Input.GetKey("w") && isGrounded && jumpTime >= .34)
			{
				if (milkCounter > 0) { rb.velocity = new Vector2(xVel, jumpForce / 8); }
				else { rb.velocity = new Vector2(xVel, jumpForce); }
				jumpTime = 0;
			}	
		}
		else if (isGrounded)
		{
			canMove = true;
		}
    }
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "floor")
		{
			isGrounded = true;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "milk")
		{
			milkCounter++;
		}
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "floor")
		{
			isGrounded = false;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "milk")
		{
			milkCounter--;
		}
	}
	
	void getHit()
	{
		if (canMove)
		{
			if (milkCounter > 0) { rb.velocity = new Vector2(((float) Random.value - 0.5f) * 5f, jumpForce / 8); }
			else { rb.velocity = new Vector2(((float) Random.value - 0.5f) * 5f, jumpForce); }
			isGrounded = false;
			canMove = false;
		}
	}
}
