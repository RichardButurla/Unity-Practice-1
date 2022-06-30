using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator enemyAnimator;
    public bool isHurt = false;
    private float hurtAnimationDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHurt)
        {
            hurtAnimationDuration += Time.deltaTime;
        }
        if (hurtAnimationDuration > 0.25)
        {
            isHurt = false;
            hurtAnimationDuration = 0;
        }
        enemyAnimator.SetBool("isHurt", isHurt);
    }

    public void hurtAnimation()
    {
        isHurt = true;
    }
}
