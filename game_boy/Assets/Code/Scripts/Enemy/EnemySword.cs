using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    [SerializeField] Vector3 Inital; 
    [SerializeField] Vector3 Target; 
    [SerializeField] Vector3 ndTarget;
    [SerializeField] float speed; 
    [SerializeField] bool rotate = false;
    private bool swung = false;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int damage;
    private bool attacking;

    // Update is called once per frame
    void Update()
    {

    }

    public void Rotate()
    {
        attacking = true;
        if (!swung)
        {
            rotate = true;
            swung = true;
        }
        StartCoroutine(RotateFromInitalToTarget());
    }

    IEnumerator RotateFromInitalToTarget()
    {
        
        while (rotate)
        {
            
            // Rotate from A to B
            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(Inital), Quaternion.Euler(Target), t);
                yield return null;
            }
            
            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(Target), Quaternion.Euler(ndTarget), t);
                yield return null;
            }

            // Rotate from B to A
            
            
            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(ndTarget), Quaternion.Euler(Inital), t);
                yield return null;
            }
            
            transform.rotation = (Quaternion.Euler(Inital));
            rotate = false;
            swung = false;
            

            


            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && attacking == true)
        {
            attacking = false;
            PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
            playerStats.DecreaseHealth(damage);
        }
        _particleSystem.Play();
    }
}

