using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public PlayerStatsSO playerStats;

    public void IncreaseHealth(int healthAmount)
    {
        playerStats.health += healthAmount;
        playerStats.health = Mathf.Clamp(playerStats.health, playerStats.minHealth, playerStats.maxHealth);
        Debug.Log("Health: " + playerStats.health);
        //TODO: Invoke UI event to update health
    }

    public void DecreaseHealth(int healthAmount)
    {
        playerStats.health -= healthAmount;
        Debug.Log("Health: " + playerStats.health);
        playerStats.health = Mathf.Clamp(playerStats.health, playerStats.minHealth, playerStats.maxHealth);
        //TODO: Invoke UI event to update health
    }

    public void IncreasePower(int powerAmount)
    {
        playerStats.power += powerAmount;
        playerStats.power = Mathf.Clamp(playerStats.power, playerStats.minPower, playerStats.maxPower);
        Debug.Log("Power: " + playerStats.power);
        //TODO: Invoke UI event to update power
    }

    public void DecreasePower(int powerAmount)
    {
        playerStats.power -= powerAmount;
        playerStats.power = Mathf.Clamp(playerStats.power, playerStats.minPower, playerStats.maxPower);
        Debug.Log("Power: " + playerStats.power);
        //TODO: Invoke UI event to update power
    }

    public void IncreaseScore(int scoreAmount)
    {
        playerStats.score += scoreAmount;
        Debug.Log("Score: " + playerStats.score);
        //TODO: Invoke UI event to update score
    }

    public void DecreaseScore(int scoreAmount)
    {
        playerStats.score -= scoreAmount;
        Debug.Log("Score: " + playerStats.score);
        //TODO: Invoke UI event to update score
    }

    public void IncreaseKey()
    {
        playerStats.keys++;
        Debug.Log("Keys: " + playerStats.keys);
        //TODO: Invoke UI event to update keys
    }

    public void DecreaseKey()
    {
        playerStats.keys--;
        Debug.Log("Keys: " + playerStats.keys);
        //TODO: Invoke UI event to update keys
    }

    public void OnEnable()
    {
        playerStats.health = playerStats.maxHealth;
    }
}
