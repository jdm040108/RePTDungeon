using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StatusManager : Singleton<StatusManager>
{

    [Header("Path")]
    public string statusPath;

    [Header("Index")]
    public List<int> Layout_Index = new List<int>();
    public List<int> Inventory_Status_Index = new List<int>();

    [Header("Skills")]
    public List<SettingWeapon> Weapon_Common = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_Rare = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_VeryRare = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_Super = new List<SettingWeapon>();

    public void InitialIndexSize()
    {
        Inventory_Status_Index.Clear();

        List<SettingWeapon> All_weapon = new List<SettingWeapon>();

        foreach (var item in Weapon_Common)
        {
            All_weapon.Add(item);
        }
        foreach (var item in Weapon_Rare)
        {
            All_weapon.Add(item);
        }
        foreach (var item in Weapon_VeryRare)
        {
            All_weapon.Add(item);
        }
        foreach (var item in Weapon_Super)
        {
            All_weapon.Add(item);
        }


        foreach (var item in All_weapon)
        {
            Inventory_Status_Index.Add(0);
        }
    }

}