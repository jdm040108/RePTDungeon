using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgradeObject : MonoBehaviour
{
    SettingWeapon thisSkill;
    [SerializeField] Image IconImage;
    [SerializeField] Text SkillName;
    [SerializeField] Text SkillLevel;
    [SerializeField] Text SkillCost;


    public void UpgradeButton()
    {
        if(InGameUIManager.Instance.coin >= thisSkill.upgradeCost)
        {
            thisSkill.level++;
            InGameUIManager.Instance.coin -= thisSkill.upgradeCost;
            thisSkill.upgradeCost = (int)(thisSkill.upgradeAmount * thisSkill.upgradeCost);

            InitializeUI();
        }
    }

    void InitializeUI()
    {
        SkillName.text = thisSkill.skill_name.ToString();
        SkillLevel.text = thisSkill.level.ToString();
        SkillCost.text = thisSkill.upgradeCost.ToString();

        IconImage.sprite = thisSkill.StateSprite[2];
    }

    public void SetData(SettingWeapon _thisSkill)
    {
        thisSkill = _thisSkill;
        InitializeUI();
    }
}
