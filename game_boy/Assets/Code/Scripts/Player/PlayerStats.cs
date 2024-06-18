using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health { get; private set; }
    public int score { get; private set; }
    public int keys { get; private set; }

    private void Awake()
    {
        keys = 1;
        health = 100;
        score = 0;
    }

    public void IncreaseHealth(int healthAmount)
    {
        health += healthAmount;
        Debug.Log("Health: " + health);
        //TODO: Invoke UI event to update health
    }

    public void DecreaseHealth(int healthAmount)
    {
        health -= healthAmount;
        Debug.Log("Health: " + health);
        //TODO: Invoke UI event to update health
    }

    public void IncreaseScore(int scoreAmount)
    {
        score += scoreAmount;
        Debug.Log("Score: " + score);
        //TODO: Invoke UI event to update score
    }

    public void DecreaseScore(int scoreAmount)
    {
        score -= scoreAmount;
        Debug.Log("Score: " + score);
        //TODO: Invoke UI event to update score
    }

    public void IncreaseKey()
    {
        keys++;
        Debug.Log("Keys: " + keys);
        //TODO: Invoke UI event to update keys
    }

    public void DecreaseKey()
    {
        keys--;
        Debug.Log("Keys: " + keys);
        //TODO: Invoke UI event to update keys
    }

}
