using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyAnimations animations;
    Transform playerToChase;
    [SerializeField] float distanceToStartChasing;

    float chasingSpeed;

    private Rigidbody rigidBody;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        animations = GetComponent<EnemyAnimations>();
    }

    private void Start()
    {
        chasingSpeed = GetComponent<Enemy>().GetStats().GetSpeed();
        playerToChase = Player.Instance().transform;
    }

    public bool IsPlayerInMovementRange()
    {
        return Vector3.Distance(playerToChase.position, transform.position) < distanceToStartChasing;
    }

    public void MoveEnemyToPlayer()
    {
        rigidBody.velocity = (playerToChase.position - transform.position).normalized * chasingSpeed;
        LookAtPlayer();
        animations.StartChasingPlayer();
    }

    public void LookAtPlayer()
    {
        transform.LookAt(playerToChase);
    }

    public void StopEnemy()
    {
        rigidBody.velocity = Vector3.zero;
        animations.StopChasingPlayer();
    }

    public bool MoveEnemyToPlayerIfInRange()
    {
        bool moving = false;
        if (IsPlayerInMovementRange())
        {
            moving = true;
            MoveEnemyToPlayer();
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
        }
        return moving;
    }
}
