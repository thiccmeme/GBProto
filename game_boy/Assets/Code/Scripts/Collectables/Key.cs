using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    PlayerStats _playerStats;
    UnityEvent increaseKey;
    private bool canCollide = true;

    private void Awake()
    {
        _playerStats = FindAnyObjectByType<PlayerStats>();
        increaseKey = new UnityEvent();
        increaseKey.AddListener(_playerStats.IncreaseKey);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canCollide)
        {
            canCollide = false;
            increaseKey.Invoke();
            Destroy(this.gameObject);
        }
    }
}
