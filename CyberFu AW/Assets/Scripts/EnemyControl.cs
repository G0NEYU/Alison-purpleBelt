using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update 
    public float speed = 5;
    public float attackingDistance = 1;
    public Vector3 direction;
    public bool isFollowingTarget;
    public bool isAttackingTarget;
    private float chasingPlayer = 0.01f;
   public float currentAttackingTime;
   public  float maxAttackingTime = 2f;

    private Animator  animatorEnemy;
    private Rigidbody rigidbodyEnemy;
    private Transform target;


     void Update()
    {
        Attack();
    }
    void FollowTarget()
    {
        if (!isFollowingTarget)
        {
            return;
        }

        if (Vector3.Distance(transform.position, target.position) >=
            attackingDistance)
        {
            direction = target.position - transform.position;
            direction.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 20); 

            if (rigidbodyEnemy.velocity.sqrMagnitude != 0)
            {
                rigidbodyEnemy.velocity = Vector3.zero;
                rigidbodyEnemy.velocity = transform.forward * speed;
                animatorEnemy.SetBool("Walk", true);
                isFollowingTarget = false;
                isAttackingTarget = true;
            }

        }

    } 

    void Attack()
    {
        if (!isAttackingTarget)
        {
            return;

        }
        currentAttackingTime += Time.deltaTime;
        if(currentAttackingTime > maxAttackingTime)
        {
            currentAttackingTime = 0f;
            animatorEnemy.SetTrigger("Attack1");
        }

        if (Vector3.Distance(transform.position, target.position) > attackingDistance + chasingPlayer) 
        {  
            isAttackingTarget = false;
            isFollowingTarget = true;
        }
    }
    void Start()
    {
        isFollowingTarget = true;
        currentAttackingTime = maxAttackingTime;
        animatorEnemy = GetComponentInChildren<Animator>();
        rigidbodyEnemy = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

       
    }

    // Update is called once per frame
   private void FixedUpdate()
    {
        FollowTarget();
    }
}

