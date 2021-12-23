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
    private bool isAttack;
    public bool IsAttack
    {
        get => isAttack;
        set
        {
            isAttack = value;
        }
    }
    [SerializeField] Animator anim;
    [SerializeField] PlayerAttackKind attackKind;
    [SerializeField] PlayerWeaponKind weaponKind;

    void Start()
    {
        
    }

    void Update()
    {
        AnimationSetting();
    }

    void AnimationSetting()
    {
        if (attackKind != (PlayerAttackKind)0 && weaponKind != (PlayerWeaponKind)0)
        {
            anim.SetInteger("AttackKind", (int)attackKind);
            anim.SetInteger("WeaponKind", (int)weaponKind);
        }
    }

    public void InitKind()
    {
        attackKind = (PlayerAttackKind)0;
        weaponKind = (PlayerWeaponKind)0;
        isAttack = false;
    }

    public void SetButtonSkill(PlayerAttackKind _attackKind, PlayerWeaponKind _weaponKind)
    {
        attackKind = _attackKind;
        weaponKind = _weaponKind;
        isAttack = true;
    }
}
