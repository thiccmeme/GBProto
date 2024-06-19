using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public PlayerStatsSO _enemyStats;
    public int currentHealth;
    
    // Start is called before the first frame update
 
    public void DecreaseHealth(int healthAmount)
    {
        _enemyStats.health -= healthAmount;
        Debug.Log("Health: " + _enemyStats.health);
        _enemyStats.health = Mathf.Clamp(_enemyStats.health, _enemyStats.minHealth, _enemyStats.maxHealth);
        //TODO: Invoke UI event to update health
    }

    void Start()
    {
        _enemyStats.health = _enemyStats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
