using UnityEngine;

[CreateAssetMenu(fileName ="New PlayerStats", menuName = "Player/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int Gold;
    public int Level;
    public int CurrentExperience;
    public int RequiredExperience { get { return Level * 25; } }
    public int Damage;

    public float rotateSpeed;


    public void AddGold(int amount)
    {
        Gold += amount;
    }

    public void GrantExperience(int amount)
    {
        CurrentExperience += amount;

        while (CurrentExperience >= RequiredExperience)
        {
            CurrentExperience -= RequiredExperience;
            Level++;
            DamageLevelUp(Level * 3);
        }
    }

    public void DamageLevelUp(int amount)
    {
        Damage += amount;
    }

    public int ReturnDamage()
    {
        return Damage;
    }
}
