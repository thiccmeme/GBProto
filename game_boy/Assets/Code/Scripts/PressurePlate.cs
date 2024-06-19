using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject lockedDoor;

    UnityEvent openDoor;

    private void Awake()
    {
        openDoor = new UnityEvent();
        //openDoor.AddListener(lockedDoor.OpenDoor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovableObject")
        {
            openDoor.Invoke();
        }
    }
}
