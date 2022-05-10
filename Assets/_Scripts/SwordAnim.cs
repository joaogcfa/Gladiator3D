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

                if (!animator.GetBool("Attack") && !animator.GetBool("Defense"))
                {
                    animator.SetBool("Attack", true);
                   
                }
            }
            if (Input.GetMouseButtonDown(1))
            {

                if (!animator.GetBool("Attack") && !animator.GetBool("Defense"))
                {
                    animator.SetBool("Defense", true);
                   
                }
            }

        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Defense", false);
        }

    }

}