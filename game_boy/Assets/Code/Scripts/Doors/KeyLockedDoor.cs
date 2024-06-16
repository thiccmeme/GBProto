using UnityEngine;
using UnityEngine.Events;

public class KeyLockedDoor : LockedDoor
{
    //[SerializeField] private GameObject _exit;
    //[SerializeField] private Sprite _openedDoorSprite; //TODO Sprite should be replaced in scene

    UnityEvent decreaseKey;
    PlayerStats _playerStats;
    //SpriteRenderer _spriteRenderer;
    //BoxCollider2D _ExitCollider;

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

    //private void OpenDoor()
    //{
    //    _ExitCollider = _exit.GetComponent<BoxCollider2D>();
    //    _ExitCollider.isTrigger = true; //"remove" collider

    //    _spriteRenderer = _exit.GetComponent<SpriteRenderer>();
    //    _spriteRenderer.sprite = _openedDoorSprite; //change exit sprite
    //}

}
