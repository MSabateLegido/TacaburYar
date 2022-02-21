using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Player.Instance().Attack().onRecieveHit.AddListener(AnimateHit);
        Player.Instance().Attack().onEndHit.AddListener(EndHitAnimation);
        Player.Instance().Attack().onPerformAttack.AddListener(OnPerformAttack);
        Player.Instance().Attack().onEndAttack.AddListener(OnEndAttack);
    }

    public void SetMovementParameter(float blendTreeNewValue)
    {
        animator.SetFloat("Movement", blendTreeNewValue);
    }

    public void StartMovingAnimation()
    {
        animator.SetBool("Moving", true);
    }

    public void StopMovingAnimation()
    {
        animator.SetBool("Moving", false);
    }

    public void AnimateHit()
    {
        animator.SetBool("Hited", true);
    }

    public void EndHitAnimation()
    {
        animator.SetBool("Hited", false);
    }

    private void OnPerformAttack()
    {
        animator.SetBool("Attack", true);
    }

    private void OnEndAttack()
    {
        animator.SetBool("Attack", true);
    }

    

}
