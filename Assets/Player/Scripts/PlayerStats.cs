using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] Stats playerBaseStats;
    private Stats currentStats;

    private int currentHp;

    private PlayerEquipmentSet playerEquipment;
    private PlayerLevel playerLevel;
    private PlayerUI playerUI;
    // Start is called before the first frame update
    void Awake()
    {
        currentStats = ScriptableObject.CreateInstance<Stats>();
        playerEquipment = GetComponent<PlayerEquipmentSet>();
        playerLevel = GetComponent<PlayerLevel>();
        playerUI = GetComponent<PlayerUI>();
    }

    private void Start()
    {
        UpdatePlayerStats();
        currentHp = currentStats.GetHP();
    }


    public void UpdatePlayerStats()
    {
        int maxHpBeforeUpdate = currentStats.GetHP();
        currentStats.SetStats(playerBaseStats);
        currentStats.AddStats(playerEquipment.GetEquipmentStats());
        currentStats.AddStats(playerLevel.GetLevelStats());
        if (maxHpBeforeUpdate != currentStats.GetHP())
        {
            playerUI.UpdateLifeBarStats(currentHp, currentStats.GetHP());
        }
        playerUI.UpdateLifeBarByHit(currentHp, currentStats.GetHP());
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
