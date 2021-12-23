using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerAttackKind
{
    NONE,
    SHEATH, //칼집에서 칼 뽑고 공격하는거 (발도)
    SIDESLASH, //횡베기
    DOWNSLASH, //종베기
    STING,
    KICK,
    GUNFIRE,
    PUNCH,
    THROW,
    SLICE,
    MAGIC,
    SELFHARM,
    GROUNDMAGIC
}

public enum PlayerWeaponKind
{
    NONE,
    LIGHTSWORD,
    BIGSWORD,
    SPEAR,
    SHOTGUN,
    GLOVES,
    KNIFE,
    GUN,
    CHINEASESABRE //언월도
}

public class PlayerController : MonoBehaviour
{
    public bool IsAttack;
    [SerializeField] Animator anim;
    [SerializeField] PlayerAttackKind attackKind;
    [SerializeField] PlayerWeaponKind weaponKind;

    [SerializeField] Transform weaponPosition;
    [SerializeField] List<WeaponBase> weapons = new List<WeaponBase>();

    void Start()
    {
        InitializeWeapon();
        SetWeapon();
    }

    void Update()
    {
        AnimationSetting();
    }

    void InitializeWeapon()
    {
        var _weapons = weaponPosition.GetComponentsInChildren<WeaponBase>();
        weapons.Clear();
        foreach (var item in _weapons)
        {
            weapons.Add(item);
        }
    }

    void AnimationSetting()
    {
        anim.SetInteger("AttackKind", (int)attackKind);
        anim.SetInteger("WeaponKind", (int)weaponKind);
    }

    public void SetWeapon()
    {
        foreach (var item in weapons)
        {
            item.gameObject.SetActive(false);
        }
        weapons[(int)weaponKind].gameObject.SetActive(true);
    }

    public void InitKind()
    {
        attackKind = (PlayerAttackKind)0;
        weaponKind = (PlayerWeaponKind)0;
        IsAttack = false;
        SetWeapon();
    }

    public void SetButtonSkill(PlayerAttackKind _attackKind, PlayerWeaponKind _weaponKind)
    {
        attackKind = _attackKind;
        weaponKind = _weaponKind;
        IsAttack = true;
        SetWeapon();
    }
}
