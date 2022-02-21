using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{

    public UnityEvent onRecieveHit;
    public UnityEvent onEndHit;
    public UnityEvent onPerformAttack;
    public UnityEvent onEndAttack;


    private bool attacking = false;

    private bool invulnerable;
    private float timeInvulnerableLeft;
    [SerializeField] private float timeInvulnerableAfterHit;


    private void Awake()
    {
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
            onRecieveHit.Invoke();
            invulnerable = true;
            timeInvulnerableLeft = timeInvulnerableAfterHit;
            gameObject.layer = Player.NON_HITABLE_LAYER;
        }
    }
    //Called by the animation RecieveHit
    public void EndHit()
    {
        onEndHit.Invoke();
    }

    public void PerformAttack()
    {
        onPerformAttack.Invoke();
        attacking = true;
    }
    //Called by the animation Attack
    public void EndAttack()
    {
        onEndAttack.Invoke();
        attacking = false;
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
