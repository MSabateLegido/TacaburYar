using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation animations;
    private CharacterController controller;
    private Vector3 playerDirection;
    private Vector3 playerMovementVector;
    private Camera gameCamera;

    [SerializeField] private float timeToRun = 0.2f;

    private bool inputRecieved;
    private bool moving = false;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerMovementVector = new Vector3();
        gameCamera = Camera.main;
        animations = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving && canMove)
        {
            playerMovementVector = Vector3.Slerp(playerMovementVector, playerDirection, timeToRun);
            animations.SetMovementParameter(playerMovementVector.magnitude / playerDirection.magnitude);
            controller.Move(playerMovementVector * Time.deltaTime);
            transform.LookAt(transform.position + playerMovementVector);
        } 
        else
        {
            if (playerMovementVector != Vector3.zero && canMove)
            {
                playerMovementVector = Vector3.Lerp(playerMovementVector, Vector3.zero, timeToRun);
                animations.SetMovementParameter(playerMovementVector.magnitude / playerDirection.magnitude);
                controller.Move(playerMovementVector * Time.deltaTime);
            }
            else
            {
                playerMovementVector = Vector3.zero;
                animations.SetMovementParameter(0);
            }
        }
    }

    public void OnMovement(InputValue value)
    {
        inputRecieved = value.Get<Vector2>() == Vector2.zero ? false : true;
        if (inputRecieved)
        {
            playerDirection = GenerateDirection(value.Get<Vector2>());
            moving = true;
        } 
        else
        {
            moving = false;
        }
    }

    private Vector3 GenerateDirection(Vector2 value)
    {
        Vector3 direction = new Vector3(value.x, 0, value.y);
        direction = gameCamera.transform.TransformDirection(direction);
        direction = Vector3.ProjectOnPlane(direction, Vector3.up).normalized * Player.Instance().Stats().GetCurrentStats().GetSpeed();
        return direction;

    }

    private void StopMoving()
    {
        if (!inputRecieved)
        {
            moving = false;
        }
    }

    public void SetMovement(bool canMove)
    {
        this.canMove = canMove;
    }
}
