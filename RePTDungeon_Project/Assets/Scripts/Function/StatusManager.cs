using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StatusManager : Singleton<StatusManager>
{
    public string path;
    public List<SettingWeapon> skills = new List<SettingWeapon>();
    public List<InventorySkillButton> skillButtons = new List<InventorySkillButton>();
    SkillSaveClass thisSave;

    void Start()
    {
        path = Application.persistentDataPath + "./Skills_Level.json";
    }

    void Update()
    {
        
    }

    public void LoadItem()
    {
        path = Application.persistentDataPath + "./Skills_Level.json";
        thisSave = new SkillSaveClass();

        if (File.Exists(path))
        {
            thisSave.Load(path);
            for (int i = 0; i < skills.Count; i++)
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
        thisSave.Save(path);
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