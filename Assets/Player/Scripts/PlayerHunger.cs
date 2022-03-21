using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour
{
    [HideInInspector] public UnityEvent onStarve;
    [SerializeField] private Image hungerBar;

    [SerializeField] private float timeToStarveSeconds = 1200;
    private float starveRate;
    private float currentHunger;

    [SerializeField] private float timeToLoseHealthWhenStarving;
    private float timeStarving;

    private void Awake()
    {
        starveRate = 1 / timeToStarveSeconds;
        currentHunger = 1;
    }

    private void Start()
    {
        EdibleItem.LazyInitializeEatEvent();
        EdibleItem.onEatEdibleItem.AddListener(EatItem);
    }

    private void EatItem(EdibleItem itemEated)
    {
        if (currentHunger < 1)
        {
            currentHunger += itemEated.GetHungerRecovery();
            timeStarving = 0;
        }
    }

    private void Update()
    {
        if (currentHunger > 0)
        {
            DecreaseHunger();
        }
        else
        {
            LoseHealth();
        }
    }

    private void DecreaseHunger()
    {
        currentHunger -= starveRate * Time.deltaTime;
        hungerBar.fillAmount = currentHunger;
    }

    private void LoseHealth()
    {
        timeStarving += Time.deltaTime;
        if (timeStarving >= timeToLoseHealthWhenStarving)
        {
            onStarve.Invoke();
            timeStarving = 0;
        }
    }
}
