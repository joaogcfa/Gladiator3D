using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    private Animator animator;

    public int EnemyHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }

        if (EnemyHealth <= 0)
        {
            print("MORREU CARAIO");
            Destroy(gameObject);
        }

        HandleAnimation();

    }

    private void HandleAnimation()
    {
        // Idle -> Attack
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            if (Vector3.Distance(target.position, transform.position) <= lookRadius)
            {

                if (!animator.GetBool("Attack") && !animator.GetBool("Impact"))
                {
                    animator.SetBool("Attack", true);
                    animator.SetBool("Idle", false);
                }
            }
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            if (Vector3.Distance(target.position, transform.position) > lookRadius)
            {

                if (!animator.GetBool("Idle") && !animator.GetBool("Impact"))
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("Attack", false);
                }
            }
        }
        

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
