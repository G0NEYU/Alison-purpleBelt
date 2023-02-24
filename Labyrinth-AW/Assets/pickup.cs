using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pickup : MonoBehaviour
{
    public Transform goal;
    private Animator animator;
    private NavMeshAgent agent;
    public Transform sphere;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        agent.destination = sphere.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sphere"))
        {
            GameObject Wall = GameObject.FindGameObjectWithTag("Wall");
            GameObject Sphere = GameObject.FindGameObjectWithTag("sphere");

            Destroy(Wall.gameObject);
            Destroy(Sphere.gameObject);

            agent.destination = goal.position;
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
