using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class InGameUIManager : Singleton<InGameUIManager>
{
    PlayerController player;

    [Header("Datas")]
    [SerializeField] List<SettingWeapon> Skills = new List<SettingWeapon>();
    public int coin;

    [Header("Skill Buttons")]
    [SerializeField] InGameSkillButton ButtonPrefab;
    [SerializeField] Transform ButtonContents;
    public List<InGameSkillButton> inGameSkills = new List<InGameSkillButton>();

    [Header("Upgrade")]
    [SerializeField] GameObject UpgradeObject;

    protected override void Awake()
    {

    }

    void Start()
    {
        player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        SetInGameSkills();
    }

    public void UpgradeObjOn()
    {
        UpgradeObject.transform.DOMoveX(0, 0.5f).SetEase(Ease.OutBack);
    }

    public void UpgradeObjOff()
    {
        UpgradeObject.transform.DOMoveX(-750, 0.5f).SetEase(Ease.OutBack);
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
