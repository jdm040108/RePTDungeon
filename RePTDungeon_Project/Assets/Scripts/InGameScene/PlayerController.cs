using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum PlayerAttackKind
{
    None,
    FastDraw, //�ߵ�
    LightSideSlash,
    LightUpSlash,
    Sting, //���
    Kick,
    HeavyChop,
    HeavySwish,
    HeavySemiCircleSlash,
    LightFastSlash,
    ShotGun,
    Biting,
    Punch,
    Throw,
    DaggerContinuous,
    BoxingPunch,
    GroundMagic,
    Sniping,
    ContinuousSlash,
    CommonMagic,
    FlameAttack,
    LightContinuousSlash,
    Iai, //�ߵ��� (!= �ߵ�)
    ShieldBlock,
    CannonShot
}

public enum PlayerWeaponKind
{
    None,
    CommonLightSword,
    CommonBigSword,
    CommonGloves,
    ShotGun,
    RareLightSword,
    RareBigSword,
    Sickle, //��
    Gauntlets,
    Dagger,
    Katana,
    ElectronicSpear,
    WireGloves,
    HeavyAxe,
    SniperMusket,
    HeavyNeedle,
    GuanDao, //�����
    AED, //��������
    EnergySword,
    FlameThrower,
    SignatureSword,
    Mimicry, //�̹�ũ��
    FireSword,
    BloodKatana, //����ȸ īŸ��
    RomanShield,
    BloodSickle, //û�Һ� ��
    HeavyBigSword,
    Cannon
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
        anim.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
        anim.gameObject.transform.DOLocalMove(Vector3.zero, 0.5f);
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
