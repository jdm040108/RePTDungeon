using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StatusManager : Singleton<StatusManager>
{
    [Header("Index")]
    public List<int> Layout_Index = new List<int>();
    public List<int> Inventory_State_Index = new List<int>();

    [Header("Skills")]
    public List<SettingWeapon> Weapon_Common = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_Rare = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_VeryRare = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_Super = new List<SettingWeapon>();

}