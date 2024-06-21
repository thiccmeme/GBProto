using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        
    }

    public void UpdateHealth()
    {
        float healthPercent = (float)stats.playerStats.health / (float)stats.playerStats.maxHealth;;
        healthBar.fillAmount = healthPercent;
        Debug.Log("Bar updated! Health is now at " + healthPercent + ", current health is " + stats.playerStats.health);
    }
}
