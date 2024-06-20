using UnityEngine;

public class LockedDoor : MonoBehaviour, IDoor
{
    [SerializeField] private GameObject _exit;
    [SerializeField] private Sprite _openedDoorSprite; //TODO Sprite should be replaced in scene

    SpriteRenderer _spriteRenderer;
    BoxCollider2D _ExitCollider;

    public void OpenDoor()
    {
        _ExitCollider = _exit.GetComponent<BoxCollider2D>();
        _ExitCollider.isTrigger = true; //"remove" collider

        _spriteRenderer = _exit.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _openedDoorSprite; //change exit sprite
    }
}
