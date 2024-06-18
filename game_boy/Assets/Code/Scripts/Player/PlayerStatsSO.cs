using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "SOs/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    public int maxHealth;
    public int minHealth;
    public int health;

    public int maxPower;
    public int minPower;
    public int power;

    public int score;
    public int keys;
}
