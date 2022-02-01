using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Transform playerToAttack;

    private EnemyAnimations animations;

    [SerializeField] private float attackRange;
    [SerializeField] private float attackArea;

    [SerializeField] private float timeBetweenAttacks = 1.5f;
    private float timeSinceLastAttack;

    private bool performingAttack = false;

    private int enemyAttack;

    private void Awake()
    {
        animations = GetComponent<EnemyAnimations>();
        timeSinceLastAttack = timeBetweenAttacks;
    }

    private void Start()
    {
        playerToAttack = Player.Instance().transform;
        enemyAttack = GetComponent<Enemy>().GetStats().GetAttack();
    }

    private void Update()
    {
        if (timeSinceLastAttack < timeBetweenAttacks)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
    }

    public void StartAttacking()
    {
        if (timeSinceLastAttack >= timeBetweenAttacks)
        {
            animations.StartAttacking();
            timeSinceLastAttack = 0;
            performingAttack = true;
        }
        else
        {
            animations.WaitingToAttack();
            if (!performingAttack)
            {
                transform.LookAt(playerToAttack);
            }
        }
    }

    public void StopAttacking()
    {
        animations.StopAttacking();
    }

    public void HitPlayer()
    {
        Player.Instance().Attack().RecieveHit(enemyAttack);
    }

    public void CheckForPlayer()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position + transform.forward * attackRange + transform.up * 0.5f, attackArea);
        foreach (Collider col in collisions)
        {
            if (col.CompareTag("Player"))
            {
                HitPlayer();
            }
        }
    }

    public void EndAttackPerformance()
    {
        performingAttack = false;
        animations.StopAttacking();
    }

    public bool IsPlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, playerToAttack.position) <= attackRange;
    }

    public bool IsPerformingAttack()
    {
        return performingAttack;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.forward * attackRange + transform.up * 0.5f, attackArea);
    }
}
