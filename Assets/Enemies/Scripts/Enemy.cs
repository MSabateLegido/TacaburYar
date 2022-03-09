using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyAnimations))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private EnemyMovement enemyMovementToPlayer;
    private EnemyAnimations animations;
    private EnemyAttack enemyAttack;
    private Rigidbody rigidBody;

    [SerializeField] private float knockbackMultiplier;

    [SerializeField] private EnemyData enemyData;
    private Stats currentStats;

    private bool attacking = false;
    

    [SerializeField] private float timeStunnedAfterHit;
    private bool stunned = false;
    private float timeStunnedLeft;

    private bool dead = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        enemyMovementToPlayer = GetComponent<EnemyMovement>();
        animations = GetComponent<EnemyAnimations>();
        enemyAttack = GetComponent<EnemyAttack>();
        currentStats = new Stats(enemyData.GetEnemyStats());
        currentStats.SetStats(enemyData.GetEnemyStats());
    }

    private void Update()
    {
        if (stunned)
        {
            StunnedUpdate();
        }
        else if (!dead)
        {
            if (attacking)
            {
                AttackUpdate();
            }
            else if (enemyMovementToPlayer.IsPlayerInMovementRange())
            {
                MovementUpdate();
            }
            else
            {
                enemyMovementToPlayer.StopEnemy();
            }
        }
    }

    private void MovementUpdate()
    {
        if (enemyAttack.IsPlayerInAttackRange())
        {
            attacking = true;
            enemyMovementToPlayer.StopEnemy();
            enemyAttack.StartAttacking();
        }
        else
        {
            enemyMovementToPlayer.MoveEnemyToPlayer();
        }
    }

    private void AttackUpdate()
    {
        if (!enemyAttack.IsPlayerInAttackRange() && !enemyAttack.IsPerformingAttack())
        {
            attacking = false;
            enemyAttack.StopAttacking();
        }
        else
        {
            enemyAttack.StartAttacking();
        }
    }

    private void StunnedUpdate()
    {
        timeStunnedLeft -= Time.deltaTime;
        if (timeStunnedLeft <= 0)
        {
            stunned = false;
            animations.EndStun();
            gameObject.layer = Player.DEFAULT_LAYER;
        }
    }

    public void RecieveHit(Vector3 playerPosition, int damage)
    {
        if (!stunned && !dead)
        {
            currentStats.MinusHP(damage);
            KnockbackEnemy(playerPosition);
            HitOrKillEnemy();
        }
    }

    private void KnockbackEnemy(Vector3 playerPosition)
    {
        Vector3 forceApplied = new Vector3(transform.position.x - playerPosition.x, 0, transform.position.z - playerPosition.z).normalized * knockbackMultiplier;
        rigidBody.AddForce(forceApplied, ForceMode.Impulse);
    }

    public void HitOrKillEnemy()
    {
        if (currentStats.GetHP() <= 0)
        {
            KillEnemy();
        }
        else
        {
            HitEnemy();
        }
    }

    public void HitEnemy()
    {
        gameObject.layer = Player.NON_HITABLE_LAYER;
        stunned = true;
        attacking = false;
        timeStunnedLeft = timeStunnedAfterHit;
        animations.GetHited();
    }

    public void KillEnemy()
    {
        animations.KillEnemy();
        dead = true;

    }

    private void DropItems()
    {
        float[] dropProbabilities = enemyData.GetDropProbabilities();
        float total = 0;
        int droppedItem = 0;
        bool dropped = false;
        foreach (float elem in dropProbabilities)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < dropProbabilities.Length; i++)
        {
            if (randomPoint < dropProbabilities[i])
            {
                if (i < enemyData.ItemsToDropCount())
                {
                    dropped = true;
                    droppedItem = i;
                }
            }
            else
            {
                randomPoint -= dropProbabilities[i];
            }
        }
        if (dropped)
        {
            Instantiate(enemyData.GetItemDropped(droppedItem), transform.position, Quaternion.identity);
        }
    }

    public void Die()
    {
        DropItems();
        Player.Instance().Level().GainExperience(enemyData.GetXPGiven());
        Destroy(gameObject);
    }

    public Stats GetStats()
    {
        return currentStats;
    }

    

}
