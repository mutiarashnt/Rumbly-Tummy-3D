using UnityEngine;
using UnityEngine.AI;

public class BearAI : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Distance")]
    public float detectDistance = 12f;
    public float attackDistance = 2f;

    [Header("Safe Zone")]
    public PlayerSafeZone playerSafe;

    private NavMeshAgent agent;
    private Animator anim;

    private bool attacking;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerSafe != null && playerSafe.IsSafe)
        {
            StopBear();
            return;
        }

        float distance =
            Vector3.Distance(
                transform.position,
                player.position);

        if (distance <= attackDistance)
        {
            Attack();
        }
        else if (distance <= detectDistance)
        {
            Chase();
        }
        else
        {
            StopBear();
        }
    }

    void Chase()
    {
        attacking = false;

        agent.isStopped = false;
        agent.SetDestination(player.position);

        anim.SetBool("Run Forward", true);
    }

    void Attack()
    {
        if (attacking)
            return;

        attacking = true;

        agent.isStopped = true;

        anim.SetBool("Run Forward", false);

        anim.SetTrigger("Attack1");
    }

    void StopBear()
    {
        attacking = false;

        agent.isStopped = true;

        anim.SetBool("Run Forward", false);
    }

    public void EndAttack()
    {
        attacking = false;
    }
}