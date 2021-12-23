using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StatusManager : Singleton<StatusManager>
{
    StatusDataSave dataSave = new StatusDataSave();

    [Header("Value")]
    public int Coin;

    [Header("Path")]
    public string statusPath;
    public string weapon_Status_Path;

    [Header("Weapon Status")]
    public WeaponStatusSave Weapon_Status_Data;

    [Header("Index")]
    public List<int> Layout_Index = new List<int>();
    public List<int> Inventory_Status_Index = new List<int>();

    [Header("Skills")]
    public List<SettingWeapon> Weapon_Common = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_Rare = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_VeryRare = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_Super = new List<SettingWeapon>();
    public List<SettingWeapon> Weapon_All = new List<SettingWeapon>();

    private void Start()
    {
        InitialIndexSize();
        InitLayoutIndex();
        InitializeWeaponStateData();
        SceneManager.LoadScene("MainScene");
    }

    public void InitializeWeaponStateData()
    {
        weapon_Status_Path = Application.persistentDataPath + "./Weapon_Status.json";
        if(File.Exists(weapon_Status_Path))
        {
            Weapon_Status_Data.Status_List.Clear();

            string json_save = File.ReadAllText(weapon_Status_Path);
            WeaponStatusSave save_temp = JsonUtility.FromJson<WeaponStatusSave>(json_save);
            foreach (var item in save_temp.Status_List)
            {
                Weapon_Status_Data.Status_List.Add(item);
            }

            for (int i = 0; i < Weapon_All.Count; i++)
            {
                Weapon_All[i].thisStatus = Weapon_Status_Data.Status_List[i];
                Weapon_All[i].SetValue();
            }
        }
        else
        {
            Weapon_Status_Data.Status_List.Clear();
            foreach (var item in Weapon_All)
            {
                Weapon_Status_Data.Status_List.Add(item.thisStatus);
            }
        }
    }

    public void SaveWeaponStatus()
    {
        Weapon_Status_Data.Status_List.Clear();
        foreach (var item in Weapon_All)
        {
            Weapon_Status_Data.Status_List.Add(item.thisStatus);
        }

        string json_save = JsonUtility.ToJson(Weapon_Status_Data, true);
        File.WriteAllText(weapon_Status_Path, json_save);
    }

    public void InitialIndexSize()
    {
        Inventory_Status_Index.Clear();

        foreach (var item in Weapon_Common)
        {
            Weapon_All.Add(item);
        }
        foreach (var item in Weapon_Rare)
        {
            Weapon_All.Add(item);
        }
        foreach (var item in Weapon_VeryRare)
        {
            Weapon_All.Add(item);
        }
        foreach (var item in Weapon_Super)
        {
            Weapon_All.Add(item);
        }
        foreach (var item in Weapon_All)
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
        SaveWeaponStatus();
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

[System.Serializable]
public class WeaponStatusSave
{
    public List<WeaponStatus> Status_List = new List<WeaponStatus>();
}

[System.Serializable]
public class WeaponStatus
{
    public int level;
    public int cost;
    public float costIncrease;
}