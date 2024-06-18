using UnityEngine;
using UnityEngine.Events;

public class KeyLockedDoor : LockedDoor
{
    UnityEvent decreaseKey;
    PlayerStats _playerStats;

    bool _isDoorOpened = false;

    private void Awake()
    {
        decreaseKey = new UnityEvent();
        _playerStats = FindAnyObjectByType<PlayerStats>();
        decreaseKey.AddListener(_playerStats.DecreaseKey);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(_playerStats.keys > 0 && !_isDoorOpened)
            {
                OpenDoor();
                decreaseKey.Invoke(); //decrease player key (playerStats)
                _isDoorOpened = true;
            }
        }
    }
}
