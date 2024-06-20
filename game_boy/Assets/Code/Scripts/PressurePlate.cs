using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject lockedDoor;

    UnityEvent openDoor;
    UnityEvent closeDoor;

    private void Awake()
    {
        openDoor = new UnityEvent();
        closeDoor = new UnityEvent();
  
        LockedDoor lockedDoorScript = lockedDoor.GetComponent<LockedDoor>();

        openDoor.AddListener(lockedDoorScript.OpenDoor);
        closeDoor.AddListener(lockedDoorScript.CloseDoor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        openDoor.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        closeDoor.Invoke();
    }
}
