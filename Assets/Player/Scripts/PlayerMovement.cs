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
    private Vector2 playerInput;
    private Camera gameCamera;

    [SerializeField] private float timeToRun = 0.2f;

    private bool moving = false;
    private bool canMove = true;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerMovementVector = new Vector3();
        playerInput = new Vector2();
        gameCamera = Camera.main;
        animations = GetComponent<PlayerAnimation>();
        speed = Player.Instance().Stats().GetCurrentStats().GetSpeed();
        AddListeners();
    }

    private void AddListeners()
    {
        Player.Instance().Attack().onRecieveHit.AddListener(OnRecieveHit);
        Player.Instance().Attack().onEndHit.AddListener(OnEndHit);
        Player.Instance().Attack().onPerformAttack.AddListener(OnPerformAttack);
        Player.Instance().Attack().onEndAttack.AddListener(OnEndAttack);
        Player.Instance().Stats().onSpeedChange.AddListener(OnSpeedChange);
        Player.Instance().Inventory().onOpenInventory.AddListener(OnOpenInventory);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moving && canMove)
        {
            playerDirection = GenerateDirection();
            playerMovementVector = Vector3.Slerp(playerMovementVector, playerDirection, timeToRun);
            animations.SetMovementParameter(playerMovementVector.magnitude / speed);
            controller.Move(playerMovementVector * Time.deltaTime);
            transform.LookAt(transform.position + playerMovementVector);
        } 
        else
        {
            if (playerMovementVector != Vector3.zero && canMove)
            {
                playerMovementVector = Vector3.Lerp(playerMovementVector, Vector3.zero, timeToRun);
                animations.SetMovementParameter(playerMovementVector.magnitude / speed);
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
        moving = value.Get<Vector2>() == Vector2.zero ? false : true;
        playerInput = value.Get<Vector2>();
    }

    private Vector3 GenerateDirection()
    {
        Vector3 direction = new Vector3(playerInput.x, 0, playerInput.y);
        direction = gameCamera.transform.TransformDirection(direction);
        direction = Vector3.ProjectOnPlane(direction, Vector3.up).normalized * speed;
        return direction;

    }

    public void SetMovement(bool canMove)
    {
        this.canMove = canMove;
    }

    private void OnRecieveHit()
    {
        SetMovement(false);
    }

    private void OnEndHit()
    {
        SetMovement(true);
    }

    private void OnPerformAttack()
    {
        SetMovement(false);
    }

    private void OnEndAttack()
    {
        SetMovement(true);
    }

    private void OnSpeedChange(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnOpenInventory(bool opened)
    {
        SetMovement(!opened);
    }
}
