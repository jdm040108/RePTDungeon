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

    [SerializeField] Animator anim;
    [SerializeField] PlayerAttackKind attackKind;
    [SerializeField] PlayerWeaponKind weaponKind;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Attack(PlayerAttackKind _attackKind, PlayerWeaponKind _weaponKind)
    {
        attackKind = _attackKind;
        weaponKind = _weaponKind;
    }
}
