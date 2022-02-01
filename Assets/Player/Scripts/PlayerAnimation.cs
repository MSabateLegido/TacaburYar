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

    public void EndHitedAnimation()
    {
        animator.SetBool("Hited", false);
    }

    public void InvulnerabilityDuring(float duration)
    {
        Sequence invulnerableSeq = DOTween.Sequence();
        invulnerableSeq.Append(transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.Linear))
                        .Append(transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.Linear))
                        .SetDelay(duration/3)
                        .SetLoops(3);
                                   //transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.Linear);
        
        ;
    }
}
