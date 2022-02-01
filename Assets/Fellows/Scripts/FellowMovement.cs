using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FellowMovement : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField] Transform playerToFollow;
    private List<Vector3> playerPositions;
    [SerializeField] int distanceFromPlayer = 50;

    private bool moving = false;

    private void Awake()
    {
        playerPositions = new List<Vector3>();
        rigidBody = GetComponent<Rigidbody>();
        playerPositions.Add(playerToFollow.position);
    }

    private void Update()
    {
        transform.LookAt(playerPositions[0]);
    }

    private void FixedUpdate()
    {
        if (PlayerMoved())
        {
            playerPositions.Add(playerToFollow.position);
            if (moving)
            {
                MoveFellow();
            }
            else
            {
                IsPlayerFarEnough();
            }

        }
    }

    private void MoveFellow()
    {
        
        rigidBody.MovePosition(playerPositions[0]);
        playerPositions.RemoveAt(0);
    }

    private void IsPlayerFarEnough()
    {
        if (Vector3.Distance(playerToFollow.position, transform.position) > 3 || playerPositions.Count >= distanceFromPlayer)
        {
            moving = true;
        }
    }

    private bool PlayerMoved()
    {
        return playerToFollow.position != playerPositions.Last();
    }
}
