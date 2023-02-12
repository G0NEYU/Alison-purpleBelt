using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    private Animator animator;
    private NavMeshAgent agent;
     
   private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (agent.hasPath)
        {
            animator.SetBool("isRunning", true);

        } else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
