using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthAmount;

    UnityEvent<int> increasehealth;
    PlayerStats _playerStats;

    private void Awake()
    {
        increasehealth = new UnityEvent<int>();

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
