using UnityEngine;
using UnityEngine.Events;

public class Power : MonoBehaviour
{
    [SerializeField] private int _powerAmount;

    UnityEvent<int> increasePower;
    PlayerStats _playerStats;

    private void Awake()
    {
        increasePower = new UnityEvent<int>();

        _playerStats = FindAnyObjectByType<PlayerStats>();
        increasePower.AddListener(_playerStats.IncreasePower);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            increasePower.Invoke(_powerAmount);
            Destroy(this.gameObject);
        }
    }
}
