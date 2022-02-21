using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
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
        playerEquipment = GetComponentInChildren<PlayerEquipmentSet>();
        playerLevel = GetComponent<PlayerLevel>();
        playerUI = GetComponent<PlayerUI>();

        
    }

    private void Start()
    {
        Player.Instance().Level().onLevelUp.AddListener(OnLevelUp);
        foreach(EquipmentItemSelector selector in Player.Instance().Equipment().GetEquipmentSelectors())
        {
            selector.onEquipmentChange.AddListener(UpdatePlayerStats);
        }
        UpdatePlayerStats();
        currentHp = currentStats.GetHP();
    }


    public void UpdatePlayerStats()
    {
        currentStats.SetStats(playerBaseStats.GetStats());
        currentStats.AddStats(playerEquipment.GetEquipmentStats());
        currentStats.AddStats(playerLevel.GetLevelStats());
        playerUI.UpdateLifeBarStats(currentHp, currentStats.GetHP());
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

    public void RecieveHit(int damageRecieved)
    {
        currentHp -= damageRecieved;
        playerUI.UpdateLifeBarByHit(currentHp, Player.Instance().Stats().GetCurrentStats().GetHP());
    }

    public Stats GetCurrentStats()
    {
        return currentStats;
    }
}
