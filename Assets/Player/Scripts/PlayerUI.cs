using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Image hpBar;
    [SerializeField] private Image hpRedBar;
    [SerializeField] private Camera mapCamera;
    
    void Start()
    {
        
    }

    public void UpdateLifeBarByHit(int currentHp, int maxHp)
    {
        hpText.text = currentHp + "/" + maxHp;
        hpBar.DOFillAmount((float)currentHp / (float)maxHp, 0.75f);
        hpRedBar.DOFillAmount((float)currentHp / (float)maxHp, 1.5f).SetDelay(0.5f);
    }

    public void UpdateLifeBarStats(int currentHp, int maxHp)
    {
        hpText.text = currentHp + "/" + maxHp;
        hpBar.fillAmount = currentHp / maxHp;
        hpRedBar.fillAmount = currentHp / maxHp;
    }

    private void OnOpenMap()
    {
        mapCamera.gameObject.SetActive(!mapCamera.gameObject.activeSelf);
    }
}
