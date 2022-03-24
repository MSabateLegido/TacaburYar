using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatsEvent : UnityEvent<Stats> { }

public class PlayerStats : MonoBehaviour
{
    [HideInInspector] public StatsEvent onStatsChange = new StatsEvent();

    [SerializeField] StatsScriptableObject playerBaseStats;
    private Stats currentStats;

    private int currentHp;

    private PlayerEquipmentSet playerEquipment;
    private PlayerLevel playerLevel;
    private PlayerBarsUI playerUI;
    // Start is called before the first frame update
    void Awake()
    {
        currentStats = new Stats(playerBaseStats.GetStats());
        currentHp = currentStats.GetHP();
        playerEquipment = GetComponentInChildren<PlayerEquipmentSet>();
        playerLevel = GetComponent<PlayerLevel>();
        playerUI = GetComponent<PlayerBarsUI>();
    }

    private void Start()
    {
        Player.Instance().Attack().onRecieveDamage.AddListener(RecieveDamage);
        Player.Instance().Level().onLevelUp.AddListener(OnLevelUp);
        foreach(EquipmentItemSelector selector in Player.Instance().Equipment().GetEquipmentSelectors())
        {
            selector.onEquipmentChange.AddListener(UpdatePlayerStats);
        }
        Player.Instance().Hunger().onStarve.AddListener(OnStarve);
        UpdatePlayerStats();
    }


    public void UpdatePlayerStats()
    {
        currentStats.SetStats(playerBaseStats.GetStats());
        currentStats.AddStats(playerEquipment.GetEquipmentStats());
        currentStats.AddStats(playerLevel.GetLevelStats());
        playerUI.UpdateLifeBarStats(currentHp, currentStats.GetHP());
        onStatsChange.Invoke(currentStats);
    }

    private void OnLevelUp()
    {
        UpdatePlayerStats();
        HealPlayer();
    }

    private void HealPlayer()
    {
        currentHp = currentStats.GetHP();
        playerUI.UpdateLifeBarStats(currentHp, currentStats.GetHP());
    }

    public void RecieveDamage(int damage)
    {
        currentHp -= damage;
        playerUI.UpdateLifeBarByHit(currentHp, Player.Instance().Stats().GetCurrentStats().GetHP());
    }

    private void OnStarve()
    {
        RecieveDamage(5);
    }

    public Stats GetCurrentStats()
    {
        return currentStats;
    }
}
