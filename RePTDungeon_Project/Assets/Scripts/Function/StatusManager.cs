using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StatusManager : Singleton<StatusManager>
{
    StatusDataSave dataSave = new StatusDataSave();

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

    public void InitLayoutIndex()
    {
        statusPath = Application.persistentDataPath + "./status_save_data.json";
        if(!File.Exists(statusPath))
        {
            Debug.Log("File not exists, initlial weapon by index");
            for (int i = 0; i < 8; i++)
            {
                Layout_Index.Add(i);
            }
        }
        else
        {
            Debug.Log("File exists, load weapon index");
            dataSave.Load(statusPath);
            Inventory_Status_Index.Clear();
            foreach (var item in dataSave.Inventory_State_Index)
            {
                Inventory_Status_Index.Add(item);
            }

            Layout_Index.Clear();
            foreach (var item in dataSave.Layout_Index)
            {
                Layout_Index.Add(item);
            }

        }
    }

    private void OnDestroy()
    {
        dataSave.SetValue(Layout_Index, Inventory_Status_Index);
        dataSave.Save(statusPath);
    }

}

[System.Serializable]
public class StatusDataSave
{
    public List<int> Layout_Index = new List<int>();
    public List<int> Inventory_State_Index = new List<int>();

    public void Save(string _path)
    {
        string json_save = JsonUtility.ToJson(this, true);
        File.WriteAllText(_path, json_save);
    }

    public void Load(string _path)
    {
        string json_save = File.ReadAllText(_path);
        StatusDataSave temp = JsonUtility.FromJson<StatusDataSave>(json_save);

        Layout_Index.Clear();
        foreach (var item in temp.Layout_Index)
        {
            Layout_Index.Add(item);
        }

        Inventory_State_Index.Clear();
        foreach (var item in temp.Inventory_State_Index)
        {
            Inventory_State_Index.Add(item);
        }
    }

    public void SetValue(List<int> _layout, List<int> _inventory)
    {
        Layout_Index.Clear();
        foreach (var item in _layout)
        {
            Layout_Index.Add(item);
        }

        Inventory_State_Index.Clear();
        foreach (var item in _inventory)
        {
            Inventory_State_Index.Add(item);
        }
    }
}