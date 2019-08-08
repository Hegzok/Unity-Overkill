using UnityEngine;

[CreateAssetMenu(fileName ="New Skin", menuName = "Skins/New Skin")]
public class Skin : ScriptableObject
{
    public string Name;

    public int Price;

    public GameObject SkinPrefab;
    public Sprite Icon;

    public Vector3 Position = new Vector3(0f, 0.05f, 0f);
    public Vector3 Rotation = new Vector3(0f, 0f, 0f);

    public bool Unlocked = false;
}
