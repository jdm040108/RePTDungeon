using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSkillButton : MonoBehaviour
{
    PlayerController player;
    [SerializeField] SettingWeapon this_Weapon;
    [SerializeField] Image thisImage;
    [SerializeField] Image iconImage;
    float skillDelay;
    float curDelay;
    bool attackAble;

    void Start()
    {
        attackAble = false;
    }

    void Update()
    {
        ImageSetting();
    }

    void IconSetting()
    {
        iconImage.sprite = this_Weapon.StateSprite[2];
    }

    void ImageSetting()
    {
        if (curDelay > 0)
        {
            thisImage.gameObject.SetActive(true);
            curDelay -= Time.deltaTime;
        }
        else
        {
            thisImage.gameObject.SetActive(false);
            curDelay = 0;
            attackAble = true;
        }
        thisImage.fillAmount = curDelay / skillDelay;
    }

    public void SetWeapon(SettingWeapon _this_weapon)
    {
        iconImage = GetComponent<Image>();
        this_Weapon = _this_weapon;
        skillDelay = _this_weapon.skill_delay;
        IconSetting();
    }

    public void SetPlayer(PlayerController _player)
    {
        player = _player;
    }

    public void SkillButtonOn()
    {
        if (player.IsAttack && attackAble)
        {
            player.SetButtonSkill(this_Weapon.this_attack_kind, this_Weapon.this_weapon_kind);
            curDelay = skillDelay;
            attackAble = false;
        }
    }
}
