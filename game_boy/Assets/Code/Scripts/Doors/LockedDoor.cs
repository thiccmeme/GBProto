using UnityEngine;

public class LockedDoor : MonoBehaviour, IDoor
{
    [SerializeField] private GameObject _exit;
    [SerializeField] private Sprite _openedDoorSprite;

    SpriteRenderer _spriteRenderer;
    BoxCollider2D _ExitCollider;
    Sprite _closedDoorSprite;

    private void Awake()
    {
        _closedDoorSprite = GetComponentInChildren<SpriteRenderer>()!.sprite;
    }

    public void OpenDoor()
    {
        _ExitCollider = _exit.GetComponent<BoxCollider2D>();
        _ExitCollider.isTrigger = true; //"remove" collider

        _spriteRenderer = _exit.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _openedDoorSprite; //change exit sprite
    }

    public void CloseDoor()
    {
        _ExitCollider = _exit.GetComponent<BoxCollider2D>();
        _ExitCollider.isTrigger = false; //"add" collider

        _spriteRenderer.sprite = _closedDoorSprite;
    }
}
