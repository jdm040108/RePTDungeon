using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUIManager : Singleton<SettingUIManager>
{

    [Header("Status")]
    public List<SettingWeapon> commonSkills = new List<SettingWeapon>();
    public List<SettingWeapon> rareSkills = new List<SettingWeapon>();
    public List<SettingWeapon> veryRareSkills = new List<SettingWeapon>();
    public List<SettingWeapon> SuperSkills = new List<SettingWeapon>();
    public InventorySkillButton buttonPrefab;
    int layoutCount;

    [Header("Skill Button Image")]
    public Button[] skillButtons;
    public Sprite[] IdleSprites;
    public Sprite[] SelectedSprites;

    [Header("Skill Setting")]
    public ScrollRect[] SkillsScroll;
    public SettingWeapon selectedWeapon;
    public InventorySkillButton selectedInventory;
    public SkillLayoutButton selectedLayout;
    public int skillTouchState; // 0: nothing, 1: skill selected, 2: skill button selected

    [Header("Setting Skill Button")]
    public SkillLayoutButton[] SkillButtonLayout;
    public GameObject thisSkillImage;
    public int curButton;

    protected override void Awake()
    {
        layoutCount = SkillsScroll.Length;
    }

    void Start()
    {
        commonSkills.Clear();
        foreach (var item in StatusManager.Instance.skills)
        {
            commonSkills.Add(item);
            InventorySkillButton I_temp = Instantiate(buttonPrefab, SkillsScroll[0].content.transform);
            I_temp.thisWeapon = item;
        }

        SetSkillLayout(0);
        thisSkillImage.gameObject.SetActive(false);
        curButton = -1;
    }

    void Update()
    {

    }

    public void SetSkillLayout(int n)
    {
        for (int i = 0; i < layoutCount; i++)
        {
            skillButtons[i].image.sprite = IdleSprites[i];
            SkillsScroll[i].gameObject.SetActive(false);
        }

        skillButtons[n].image.sprite = SelectedSprites[n];
        SkillsScroll[n].gameObject.SetActive(true);
    }

    public void SetLayoutButton(int n)
    {

    }

    public void SetSkillImage()
    {
        if (curButton >= 0)
        {
            thisSkillImage.gameObject.SetActive(true);
            thisSkillImage.transform.position = SkillButtonLayout[curButton].transform.position;
        }
        else
        {
            thisSkillImage.gameObject.SetActive(false);
        }
    }

}
