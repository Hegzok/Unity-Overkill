using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public delegate void WeaponUpdateEventHandler(Weapon weapon);
    public static event WeaponUpdateEventHandler OnUpdateWeaponUI;
    public static event WeaponUpdateEventHandler OnUpdateWeapon;

    public delegate void SkinUpdateEventHandler(Skin skin);
    public static event SkinUpdateEventHandler OnSkinUpdate;

    public delegate void GameStateEventHandler(bool playGame);
    public static event GameStateEventHandler OnGameStateChange;

    public static void UpdateWeaponUI(Weapon weapon)
    {
        if (OnUpdateWeaponUI != null)
        {
            OnUpdateWeaponUI(weapon);
        }
    }

    public static void UpdateWeapon(Weapon weapon)
    {
        if (OnUpdateWeapon != null)
        {
            OnUpdateWeapon(weapon);
        }
    }

    public static void UpdateSkin(Skin skin)
    {
        if (OnSkinUpdate != null)
        {
            OnSkinUpdate(skin);
        }
    }

    public static void ChangeGameState(bool playGame)
    {
        if (OnGameStateChange != null)
        {
            OnGameStateChange(playGame);
        }
    }

}
