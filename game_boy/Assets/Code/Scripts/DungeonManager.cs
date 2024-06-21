using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    protected bool isActive = false;

    protected virtual void Activate()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {

            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    protected virtual void DeActivate()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isActive = true;

            Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isActive = false;

            DeActivate();
        }
    }

}
