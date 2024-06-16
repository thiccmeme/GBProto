using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthEvent : UnityEvent<int>
{
}

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthAmount;

    HealthEvent increasehealth;
    PlayerStats _playerStats;

    private void Awake()
    {
        increasehealth = new HealthEvent();

        _playerStats = FindAnyObjectByType<PlayerStats>();
        increasehealth.AddListener(_playerStats.IncreaseHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            increasehealth.Invoke(_healthAmount);
            Destroy(this.gameObject);
        }
    }
}
