using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour
{
    [SerializeField] private Image hungerBar;

    [SerializeField] private float timeToStarveSeconds = 1200;
    private float starveRate;

    private void Awake()
    {
        starveRate = 1 / timeToStarveSeconds;
    }
    private void Update()
    {
        hungerBar.fillAmount -= starveRate * Time.deltaTime;
    }
}
