using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : UnitSprite
{
    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from the enemy!");
        }
    }

    public void Pushback(Vector2 force)
    {
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    public override void Die()
    {
        Destroy(gameObject); // Destroy the GameObject instead of 'this'
        Debug.Log("BaseEnemy has died.");
    }
}