using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrade : MonoBehaviour
{
    [Header("UI object")]
    [SerializeField] Image iconImage;
    [SerializeField] Text skill_name_txt;
    [SerializeField] Text skill_desc_txt;

    [Header("Value")]
    [SerializeField] Sprite Icon;
    [SerializeField] Sprite noneIcon;
    public SettingWeapon thisSkill;
    string s_skill_name;
    string s_skill_desc;

    void SetText()
    {
        skill_name_txt.text = s_skill_name;
        skill_desc_txt.text = s_skill_desc;
    }

    void SetSprite()
    {
        iconImage.sprite = Icon;
    }

    public void SetData(SettingWeapon _thisWeapon)
    {
        thisSkill = _thisWeapon;
        if(thisSkill != null)
        {
            Icon = _thisWeapon.StateSprite[2];
            s_skill_name = _thisWeapon.skill_name;
            s_skill_desc = _thisWeapon.skill_desc;
        }
        else
        {
            Icon = noneIcon;
            s_skill_name = "스킬 없음";
            s_skill_desc = "스킬 없음";
        }

        SetSprite();
        SetText();
    }

    public void Upgrade()
    {

    }
}
