using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image[] keys;

    public void UpdateHealth()
    {
        float healthPercent = (float)stats.playerStats.health / (float)stats.playerStats.maxHealth;;
        healthBar.fillAmount = healthPercent;
        //Debug.Log("Bar updated! Health is now at " + healthPercent + ", current health is " + stats.playerStats.health);
    }

    public void UpdateKeys()
    {
        for (int i = 0; i < stats.playerStats.keys; i++)
        {
            keys[i].gameObject.SetActive(true);
            keys[Mathf.Clamp(i+stats.playerStats.keys,0,keys.Length)].gameObject.SetActive(false);
        }
        if (stats.playerStats.keys == 0) //if player has no keys, set all keys disabled - this is to handle an edge case when the player only has one key
        {
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i].gameObject.SetActive(false);
            }
        }
        //Debug.Log("keys updated!");
    }
}
