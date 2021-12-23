using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill", fileName = "Scriptable Skill", order = int.MaxValue)]
public class SettingWeapon : ScriptableObject
{
    public int State; //0: locked, 1: unloced, 2: selected
    public Sprite[] StateSprite; //0:locked, 1: unlocked, 2:selected

    public string skill_name;
    public string skill_desc;

    public float skill_delay;

    public int upgradeCost;
    public float upgradeAmount;

    public PlayerAttackKind this_attack_kind;
    public PlayerWeaponKind this_weapon_kind;
}
