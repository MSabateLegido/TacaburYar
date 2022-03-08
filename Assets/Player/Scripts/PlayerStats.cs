using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEvent : UnityEvent<float> { }

public class PlayerStats : MonoBehaviour
{
    [HideInInspector] public FloatEvent onSpeedChange;

    [SerializeField] StatsScriptableObject playerBaseStats;
    private Stats currentStats;

    private int currentHp;

    private PlayerEquipmentSet playerEquipment;
    private PlayerLevel playerLevel;
    private PlayerUI playerUI;
    // Start is called before the first frame update
    void Awake()
    {
        currentStats = new Stats(playerBaseStats.GetStats());
        onSpeedChange = new FloatEvent();
        currentHp = currentStats.GetHP();
        playerEquipment = GetComponentInChildren<PlayerEquipmentSet>();
        playerLevel = GetComponent<PlayerLevel>();
        playerUI = GetComponent<PlayerUI>();

        
    }

    private void Start()
    {
        Player.Instance().Attack().onRecieveDamage.AddListener(RecieveDamage);
        Player.Instance().Level().onLevelUp.AddListener(OnLevelUp);
        foreach(EquipmentItemSelector selector in Player.Instance().Equipment().GetEquipmentSelectors())
        {
            selector.onEquipmentChange.AddListener(UpdatePlayerStats);
        }
        UpdatePlayerStats();
    }


    public void UpdatePlayerStats()
    {
        currentStats.SetStats(playerBaseStats.GetStats());
        currentStats.AddStats(playerEquipment.GetEquipmentStats());
        currentStats.AddStats(playerLevel.GetLevelStats());
        playerUI.UpdateLifeBarStats(currentHp, currentStats.GetHP());
        onSpeedChange.Invoke(currentStats.GetSpeed());
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

    public Stats GetCurrentStats()
    {
        return currentStats;
    }
}
