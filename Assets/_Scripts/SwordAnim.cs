using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnim : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        HandleAnimation();

    }

    private void HandleAnimation()
    {

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Swordidle"))
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (!animator.GetBool("Attack"))
                {
                    animator.SetBool("Attack", true);
                    // int i = Random.Range(1, 4);
                    // if (i == 1)
                    // {
                    //     animator.SetBool("isBoxing", true);
                    // }
                    // else if (i == 2)
                    // {
                    //     animator.SetBool("isElbow", true);
                    // }
                    // else if (i == 3)
                    // {
                    //     animator.SetBool("isJab", true);
                    // }
                }
            }

        }
        else
        {
            animator.SetBool("Attack", false);

        }

    }

}