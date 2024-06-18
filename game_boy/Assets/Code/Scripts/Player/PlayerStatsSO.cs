using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "SOs/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    public int health;
    public int score;
    public int keys;
}
