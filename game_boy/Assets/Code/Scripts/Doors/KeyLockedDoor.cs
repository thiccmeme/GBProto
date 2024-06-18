using UnityEngine;
using UnityEngine.Events;

public class KeyLockedDoor : LockedDoor
{
    PlayerStats _playerStats;
    UnityEvent decreaseKey;

    bool _isDoorOpened = false;

    private void Awake()
    {
        _playerStats = FindAnyObjectByType<PlayerStats>();

        decreaseKey = new UnityEvent();
        decreaseKey.AddListener(_playerStats.DecreaseKey);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(_playerStats.playerStats.keys > 0 && !_isDoorOpened)
            {
                OpenDoor();
                decreaseKey.Invoke(); //decrease player key (playerStats)
                _isDoorOpened = true;
            }
        }
    }
}
