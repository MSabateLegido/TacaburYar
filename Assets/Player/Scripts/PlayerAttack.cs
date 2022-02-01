using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;

    private bool attacking = false;

    private bool invulnerable;
    private float timeInvulnerableLeft;
    [SerializeField] private float timeInvulnerableAfterHit;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (invulnerable)
        {
            timeInvulnerableLeft -= Time.deltaTime;
            if (timeInvulnerableLeft <= 0)
            {
                invulnerable = false;
                gameObject.layer = Player.DEFAULT_LAYER;
            }
        }
    }

    //Called by the animation
    public void CheckForEnemies()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position + transform.forward * 1.2f + transform.up, 0.9f);
        foreach (Collider col in collisions)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Enemy>().RecieveHit(transform.position, 10);//10 = player attack
            }

        }
    }

    public void RecieveHit(int damageRecieved)
    {
        if (!invulnerable)
        {
            Player.Instance().Stats().RecieveHit(damageRecieved);
            Player.Instance().Movement().SetMovement(false);
            Player.Instance().Animations().AnimateHit();
            invulnerable = true;
            timeInvulnerableLeft = timeInvulnerableAfterHit;
            gameObject.layer = Player.NON_HITABLE_LAYER;
        }
    }

    public void EndHit()
    {
        Player.Instance().Movement().SetMovement(true);
        Player.Instance().Animations().EndHitedAnimation();
    }

    public void PerformAttack()
    {
        movement.SetMovement(false);
        attacking = true;
        animator.SetBool("Attack", true);
    }

    public void EndAttack()
    {
        movement.SetMovement(true);
        attacking = false;
        animator.SetBool("Attack", false);
    }

    private void OnAttack()
    {
        if (!attacking)
        {
            PerformAttack();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.forward * 1.2f + transform.up, 0.9f);
    }
}
