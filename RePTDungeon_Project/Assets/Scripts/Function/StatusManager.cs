using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StatusManager : Singleton<StatusManager>
{
    public string itemSave_path;
    public string layoutSave_path;

    public List<InventorySkillButton> skillButtons = new List<InventorySkillButton>();
    public List<int> skillLayout_index = new List<int>();
    public List<SettingWeapon> weapon_index = new List<SettingWeapon>();
    SkillSaveClass thisSave;



    void Start()
    {
        itemSave_path = Application.persistentDataPath + "./Skills_Level.json";
        layoutSave_path = Application.persistentDataPath + "./Layout.json";
    }

    void Update()
    {
        
    }

    public void LoadItem()
    {
        itemSave_path = Application.persistentDataPath + "./Skills_Level.json";
        thisSave = new SkillSaveClass();

        if (File.Exists(itemSave_path))
        {
            thisSave.Load(itemSave_path);
            for (int i = 0; i < skillButtons.Count; i++)
            {
                skillButtons[i].state = thisSave.SkillsState[i];
            }
        }
        else
        {
            thisSave.SetData(skillButtons);
        }
    }

    private void OnDestroy()
    {
        thisSave.SetData(skillButtons);
        thisSave.Save(itemSave_path);
    }
}

[System.Serializable]
public class SkillSaveClass
{
    //States
    public List<int> SkillsState = new List<int>();

    public void SetData(List<InventorySkillButton> list)
    {
        SkillsState.Clear();
        foreach (var item in list)
        {
            SkillsState.Add(item.state);
        }
    }

    public void Save(string _path)
    {
        SkillSaveClass temp = new SkillSaveClass();

        temp.SkillsState.Clear();
        foreach (var item in SkillsState)
        {
            temp.SkillsState.Add(item);
        }

        string json_save = JsonUtility.ToJson(temp, true);
        File.WriteAllText(_path, json_save);
    }

    public SkillSaveClass Load(string _path)
    {
        if(File.Exists(_path))
        {
            SkillSaveClass temp_save = new SkillSaveClass();
            string json_save = File.ReadAllText(_path);

            temp_save = JsonUtility.FromJson<SkillSaveClass>(json_save);

            SkillsState.Clear();
            foreach (var item in temp_save.SkillsState)
            {
                SkillsState.Add(item);
            }
        }

        return this;
    }
}

[System.Serializable]
public class SkillLayoutSave
{

}