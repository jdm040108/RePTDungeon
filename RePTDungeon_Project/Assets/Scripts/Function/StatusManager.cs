using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StatusManager : Singleton<StatusManager>
{

    public List<SettingWeapon> skills = new List<SettingWeapon>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

[System.Serializable]
public class SkillSaveClass
{
    //States
    public List<int> SkillsState = new List<int>();

    public void Save(string _path)
    {
        string json_save = JsonUtility.ToJson(this);
        File.WriteAllText(_path, json_save);
    }

    public SkillSaveClass Load(string _path)
    {
        if(File.Exists(_path))
        {
            
        }


        return this;
    }
}