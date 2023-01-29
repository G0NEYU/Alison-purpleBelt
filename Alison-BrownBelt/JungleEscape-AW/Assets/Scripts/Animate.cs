using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    // Start is called before the first frame update 
    Animator Animator;
    Jump Jump;
    void Start()
    {
        Animator = GetComponent<Animator>();
        Jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Jump.isGrounded)
        {
           Animator.SetBool("isJumping", true);
            Animator.SetBool("isIdle", false);
            Animator.SetBool("isWalking", false);
            Animator.SetBool("isWalkingBackwards", false);

        } 
        if (Jump.isGrounded)
        {
            if (Input.GetAxisRaw("Vertical") ==1)
            {
                Animator.SetBool("isIdle", true);
                Animator.SetBool("isWalking", false);
                Animator.SetBool("isWalkingBackwards", false);
                    
            } 
            if(Input.GetAxisRaw("Vertical") ==-1)
            {
            
                Animator.SetBool("IsWalkingBackwards", true);
                Animator.SetBool("IsWalking", false);
                Animator.SetBool("IsIdle", false);
            }
        }
    }
}
