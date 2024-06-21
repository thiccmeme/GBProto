using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public PlayerStatsSO playerStats;
    [SerializeField] private HUDManager hud;
    [SerializeField] private GameOverManager _gameOverManager;
    private void OnEnable() 
    {
        playerStats.health = playerStats.maxHealth;
        playerStats.power = playerStats.maxPower;
        playerStats.keys = 0;
    }

    public void IncreaseHealth(int healthAmount)
    {
        playerStats.health += healthAmount;
        playerStats.health = Mathf.Clamp(playerStats.health, playerStats.minHealth, playerStats.maxHealth);
        Debug.Log("Health: " + playerStats.health);
        hud.UpdateHealth();
    }

    public void DecreaseHealth(int healthAmount)
    {
        playerStats.health -= healthAmount;
        Debug.Log("Health: " + playerStats.health);
        playerStats.health = Mathf.Clamp(playerStats.health, playerStats.minHealth, playerStats.maxHealth);
        if(playerStats.health <= 0)
            Die();
        hud.UpdateHealth();
    }

    public void Die()
    {
        _gameOverManager.HandleGameOver();
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
        hud.UpdateKeys();
    }

    public void DecreaseKey()
    {
        playerStats.keys--;
        Debug.Log("Keys: " + playerStats.keys);
        hud.UpdateKeys();
    }
}
