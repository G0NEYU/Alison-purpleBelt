using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update 
    public float speed = 5;
    public float attackingDistance = 1;
    public Vector3 direction;
    private bool isFollowingTarget;
    private bool isAttackingTarget;
    private float chasingPlayer = 0.01f;
    private float currentAttackingTime;
    private float maxAttackingTime = 2f;

    private Animator  animatorEnemy;
    private Rigidbody rigidbodyEnemy;
    private Transform target;
    void Start()
    {
        isFollowingTarget = true;
        currentAttackingTime = maxAttackingTime;
        animatorEnemy = GetComponentInChildren<Animator>();
        rigidbodyEnemy = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (!isFollowingTarget)
        {
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
