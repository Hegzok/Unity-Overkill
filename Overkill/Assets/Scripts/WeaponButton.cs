using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI weaponName;
    

    // Use this for initialization
    void Start()
    {
        weaponName.text = weapon.Name;
        icon.sprite = weapon.Icon;
    }

    public void UpdateWeaponUI()
    {
        EventsManager.UpdateWeaponUI(weapon);
    }
}
