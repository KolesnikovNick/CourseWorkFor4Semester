using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseMode : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent myAgent;
    private Animator myAnimator;

    public Transform target;
    public Transform targetOff;
    
    public bool chaseTarget = true;
    public float stopingDistance = 2.5f;
    public float delayBetweenAttacks = 1.5f;
    private float attackCooldown;
    
    private float distanceFromTarget;

    public int damage = 50;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();  
        myAnimator = GetComponent<Animator>();
        myAgent.stoppingDistance = stopingDistance;
        attackCooldown = Time.time;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        ChaseTarget();
    }
    void ChaseTarget(){
        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        if(distanceFromTarget >=stopingDistance){
            chaseTarget = true;
        }
        else {
            chaseTarget = false;
            Attack();
        }

        if (distanceFromTarget < 15)
        {
            if (chaseTarget)
            {
                chaseTarget = true;
                myAgent.SetDestination(target.position);
                myAnimator.SetBool("isChasing", true);
            }
        }
        else
        {
            StartCoroutine(Stalk());
        }
    }

    void Attack(){
        if(Time.time > attackCooldown)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Attack!");
            myAnimator.SetTrigger("Attack");
            attackCooldown = Time.time + delayBetweenAttacks;
        }
    }

    public IEnumerator Stalk()
    {
        chaseTarget = false;
        myAgent.ResetPath();
        myAnimator.SetBool("isChasing", false);
        yield return new WaitForSeconds(3);
        chaseTarget = true;
        myAgent.SetDestination(target.position);
        myAnimator.SetBool("isChasing", true);
        yield return new WaitForSeconds(3);
    }
}
