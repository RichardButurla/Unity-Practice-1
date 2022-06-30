using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    public float MAX_SPEED = 5f;
    private float speed = 5f;

    private bool isAttacking = false;
    private float attackAnimationTime = 0f;

    private bool isBlocking = false;
    private float blockAnimationTime = 0f;

    float playerXScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerScale = transform.localScale;
        playerXScale = Mathf.Abs(playerScale.x);

        //handle movement animation here
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            speed = MAX_SPEED;
            if (!isAttacking)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    if(!isBlocking)
                    playerScale.x = -playerXScale;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    if(!isBlocking)
                    playerScale.x = playerXScale;
                }
                animator.SetFloat("Speed", Mathf.Abs(speed));
                transform.localScale = playerScale;
            }
            
        }
        else
        {
            speed = 0f;
            animator.SetFloat("Speed", Mathf.Abs(speed));
        }


        //handle attacking animation here
        if (isAttacking)
        {
            attackAnimationTime += 0.016f;
        }
        if (attackAnimationTime > 2)
        {
            isAttacking = false;
            attackAnimationTime = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
        }
        animator.SetBool("isAttacking", isAttacking);

        //handle blocking animation here
        if (isBlocking)
        {
            blockAnimationTime += 0.016f;
        }
        if (blockAnimationTime > 1)
        {
            isBlocking = false;
            blockAnimationTime = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isBlocking = true;
        }
        animator.SetBool("isBlocking", isBlocking);

    }
}
