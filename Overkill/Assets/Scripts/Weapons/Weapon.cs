using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="Weapons/New Weapon")]
public class Weapon : ScriptableObject
{
    public string Name;

    public WeaponType WType;

    public Mesh Mesh;
    public Material Material;
    public Vector3 Rotation = new Vector3(-90f, -90f, 0f);
    public Vector3 Position;

    public Sprite Icon;
    public GameObject Ammunition;


    public int Price;
    public int Level;
    public int Damage;

    public string Description;

    public bool Unlocked = false;
}
