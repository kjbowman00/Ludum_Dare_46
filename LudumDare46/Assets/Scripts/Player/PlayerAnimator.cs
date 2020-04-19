using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxis("Horizontal");
        if (axis == 0)
        {
            animator.SetBool("Moving", false);
        }
        else if (axis > 0)
        {
            animator.SetBool("Moving", true);
            sr.flipX = false;
        }
        else if (axis < 0)
        {
            animator.SetBool("Moving", true);
            sr.flipX = true;
        }
    }
}
