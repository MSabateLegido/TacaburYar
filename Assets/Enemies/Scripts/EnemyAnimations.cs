using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartChasingPlayer()
    {
        animator.SetBool("Chasing", true);
        OpenEye();
    }

    public void StopChasingPlayer()
    {
        animator.SetBool("Chasing", false);
        IdleEye();
    }

    public void GetHited()
    {
        animator.SetBool("Hited", true);
        animator.SetBool("Stunned", true);
        StopAttacking();
        StopChasingPlayer();
    }

    public void OpenEye()
    {
        animator.SetLayerWeight(1, 1f);
    }

    public void IdleEye()
    {
        animator.SetLayerWeight(1, 0f);
    }

    public void EndStun()
    {
        animator.SetBool("Stunned", false);
        animator.SetBool("Hited", false);
    }

    public void KillEnemy()
    {
        animator.SetBool("Die", true);
    }

    public void StartAttacking()
    {
        animator.SetBool("Attacking", true);
        animator.SetBool("PlayerInAttackRange", true);
    }

    public void StopAttacking()
    {
        animator.SetBool("Attacking", false);
        animator.SetBool("PlayerInAttackRange", false);
    }

    public void WaitingToAttack()
    {
        animator.SetBool("PlayerInAttackRange", true);
    }
}
