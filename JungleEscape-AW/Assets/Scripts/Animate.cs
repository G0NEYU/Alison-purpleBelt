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
           // Animator.SetBool("isJumping, true");
            //Animator.SetBool("isIdle, false");
           // Anima
        } 
        if (Jump.isGrounded)
        {
            if (Input.GetAxisRaw("Vertical") ==1)
            {

            } 
            if(Input.GetAxisRaw("Vertical") ==-1)
            {

            }
        }
    }
}
