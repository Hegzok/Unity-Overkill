using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponsPanel : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private PlayerWeapon playerWeapon;
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI weaponDescription;
    [SerializeField] private TextMeshProUGUI weaponDamageText;
    [SerializeField] private TextMeshProUGUI weaponPriceText;

    [SerializeField] private Text BuyButtonText;

    // Use this for initialization
    void Start()
    {
        currentWeapon = playerWeapon.ReturnCurrentWeapon();
        UpdateWeaponUI(currentWeapon);

        HandleEvents(true);
    }

    private void OnDestroy()
    {
        HandleEvents(false);
    }

    private void HandleEvents(bool switcher)
    {
        if (switcher)
        {
            EventsManager.OnUpdateWeaponUI += UpdateWeaponUI;
        }
        else
        {
            EventsManager.OnUpdateWeaponUI -= UpdateWeaponUI;
        }
    }

    private void UpdateWeaponUI(Weapon weapon)
    {
        currentWeapon = weapon;

        weaponName.text = weapon.Name;
        weaponDescription.text = weapon.Description;
        weaponDamageText.text = "Damage: " + weapon.Damage.ToString();
        weaponPriceText.text = "Price: " + weapon.Price.ToString();

        if (currentWeapon.Unlocked)
        {
            BuyButtonText.text = "EQUIP";
        }
        else
        {
            BuyButtonText.text = "BUY";
        }
    }

    public void BuyOrEquip()
    {
        if (currentWeapon.Unlocked)
        {
            EventsManager.UpdateWeapon(currentWeapon);
        }

        if (playerStats.Gold >= currentWeapon.Price && !currentWeapon.Unlocked)
        {
            playerStats.Gold -= currentWeapon.Price;
            currentWeapon.Unlocked = true;
            SaveManager.Instance.SaveAllData();
            BuyButtonText.text = "EQUIP";
        }
        else if (playerStats.Gold < currentWeapon.Price && !currentWeapon.Unlocked)
        {
            Debug.Log("Not enough gold to buy: " + currentWeapon.Name + " You need " + (currentWeapon.Price - playerStats.Gold) + " more to buy this weapon");
        }
    }
}
