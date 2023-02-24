using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveToSphere : MonoBehaviour
{
    public Transform Sphere;
    private Animator animator;
    private NavMeshAgent agent;
    public Transform goal;
    public bool hasreach;
    
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = Sphere.position;
    }

    // Update is called once per frame
    void Update()
    {
        {
           //if (gameObject.)
            //{
              //  agent.destination = goal.position;
            //}
            if (agent.hasPath)
            {
                animator.SetBool("isRunning", true);

            }
            else
            {
                animator.SetBool("isRunning", false);
            }
            
            
        }
    }
}