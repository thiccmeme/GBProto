using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float swingAngle = 45f; // Angle to swing to in each direction
    [SerializeField] private float speed = 5f; // Speed of the swing
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int damage = 10;
    [SerializeField] private bool useInput = false;
    [SerializeField] private float pushbackForce = 5f; // Force applied to pushback the enemy
    [SerializeField] private AudioSource _audio;
    [SerializeField] private GameObject pivotPoint;
    
    private bool rotate = false;
    private bool swung = false;
    private bool attacking = false;
    public string EnemyTag = "Enemy";
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private Quaternion ndTargetRotation;
    private PlayerDirection _dir;

    private void Awake() //maybe redundant with start function, but want to be safe and not overwrite things
    {
        _dir = GetComponentInParent<PlayerDirection>();
    }

    private void Start()
    {
        UpdateRotations();
    }

    public void UpdateRotations()
    {
        initialRotation = transform.localRotation;
        targetRotation = initialRotation * Quaternion.Euler(0, 0, swingAngle);
        ndTargetRotation = initialRotation * Quaternion.Euler(0, 0, -swingAngle);
    }

    private void FixedUpdate()
    {
        UpdateSwordPivot();
    }

    private void UpdateSwordPivot() 
    {
        switch (_dir.GetFacingDirection())
        {
            case 0:
            case 1:
            case 2:
            case 8:
                pivotPoint.transform.localRotation = Quaternion.Euler(0, 0, 270f);
                break;
            case 3:
                pivotPoint.transform.localRotation = Quaternion.Euler(0, 0, 0f);
                break;
            case 4:
            case 5:
            case 6:
                pivotPoint.transform.localRotation = Quaternion.Euler(0, 0, 90f);
                break;
            case 7:
                pivotPoint.transform.localRotation = Quaternion.Euler(0, 0, 180f);
                break;
        }
    }

    public void Attack()
    {
        attacking = true;
        if (!swung)
        {
            rotate = true;
            StartCoroutine(RotateSword());
            swung = true;
        }
    }

    private void Update()
    {
        if (useInput == false) return;

        if (Input.GetMouseButtonDown(0) && !rotate)
        {
            Attack();
        }
    }

    private IEnumerator RotateSword()
    {
        while (rotate)
        {
            // Rotate from initial to target
            yield return RotateTo(targetRotation);
            // Rotate from target to ndTarget
            yield return RotateTo(ndTargetRotation);
            // Rotate from ndTarget back to initial
            yield return RotateTo(initialRotation);

            rotate = false;
            swung = false;
        }
    }

    private IEnumerator RotateTo(Quaternion target)
    {
        while (Quaternion.Angle(transform.localRotation, target) > 0.1f)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, target, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (attacking)
        {
            if (other.CompareTag(EnemyTag))
            {
                attacking = false;
                EnemyStats enemyStats = other.gameObject.GetComponent<EnemyStats>();
                BaseEnemy enemy = other.gameObject.GetComponent<BaseEnemy>();

                if (enemyStats != null)
                {
                    enemyStats.DecreaseHealth(damage);
                     _audio.Play();

                    if (enemyStats._enemyStats.health < 3)
                    {
                        Destroy(other.gameObject);
                    }
                }

                if (enemy != null)
                {
                    // Calculate pushback direction
                    Vector2 pushDirection = (other.transform.position - transform.position).normalized;
                    enemy.Pushback(pushDirection * pushbackForce);
                }

                _particleSystem.Play();
            }
            else if (other.CompareTag("Player"))
            {
                attacking = false;
                PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();

                if (playerStats != null)
                {
                    playerStats.DecreaseHealth(damage);
                }

                _particleSystem.Play();
            }
           
        }
    }

}
