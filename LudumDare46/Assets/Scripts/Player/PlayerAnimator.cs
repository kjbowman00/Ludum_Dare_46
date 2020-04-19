using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public float threshold;
    Animator animator;
    SpriteRenderer sr;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xVel = rb.velocity.x;
        if (xVel > threshold)
        {
            animator.SetBool("Moving", true);
            sr.flipX = false;
        }
        else if (xVel < -threshold)
        {
            animator.SetBool("Moving", true);
            sr.flipX = true;
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
