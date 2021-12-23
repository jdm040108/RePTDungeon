using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    PlayerController player;

    [Header("Datas")]
    [SerializeField] List<SettingWeapon> Skills = new List<SettingWeapon>();

    [Header("Skill Buttons")]
    [SerializeField] InGameSkillButton ButtonPrefab;
    [SerializeField] Transform ButtonContents;
    public List<InGameSkillButton> inGameSkills = new List<InGameSkillButton>();

    void Start()
    {
        player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        SetInGameSkills();
    }

    void Update()
    {
        
    }

    void GetSkills()
    {
        Skills.Clear();
        foreach (var item in StatusManager.Instance.Weapon_All)
        {
            Skills.Add(item);
        }


    }

    public void MoveLoadoutScene()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void SetInGameSkills()
    {
        GetSkills();
        for (int i = 0; i < 8; i++)
        {
            InGameSkillButton button_temp = Instantiate(ButtonPrefab, ButtonContents);
            button_temp.SetPlayer(player);
            button_temp.SetWeapon(Skills[StatusManager.Instance.Layout_Index[i]]);
            inGameSkills.Add(button_temp);
        }
    }
}
