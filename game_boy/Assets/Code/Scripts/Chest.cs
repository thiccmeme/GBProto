using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject _chest;
    [SerializeField] private Sprite _openedChestSprite; //TODO Sprite should be replaced in scene
    [SerializeField] private GameObject[] _collectables;

    PlayerStats _playerStats;
    UnityEvent decreaseKey;
    SpriteRenderer _spriteRenderer;
    BoxCollider2D _ExitCollider;

    bool _isChestOpened = false;

    private void Awake()
    {
        _playerStats = FindAnyObjectByType<PlayerStats>();

        decreaseKey = new UnityEvent();
        decreaseKey.AddListener(_playerStats.DecreaseKey);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_playerStats.playerStats.keys > 0 && !_isChestOpened)
            {
                OpenChest();
                SpawnCollectables();
                decreaseKey.Invoke(); //decrease player key (playerStats)
                _isChestOpened = true;
            }
        }
    }

    public void OpenChest()
    {
        _ExitCollider = _chest.GetComponent<BoxCollider2D>();
        _ExitCollider.isTrigger = true; //"remove" collider

        _spriteRenderer = _chest.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _openedChestSprite; //change exit sprite
    }

    public void SpawnCollectables()
    {
        int collectableIndex = Random.Range(0, _collectables.Length);
        GameObject collectable = Instantiate(_collectables[collectableIndex], transform.position, Quaternion.identity);
        //collectable = collectable.transform.Translate(collectable.transform.position + collectable.transform.position.); TODO finish collectable movement

        Debug.Log("Spawning: " + _collectables[collectableIndex]);
    }
}
