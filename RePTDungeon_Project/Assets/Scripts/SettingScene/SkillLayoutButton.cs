using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLayoutButton : MonoBehaviour
{
    Button thisButton;
    Image thisImage;
    public int state = 0;
    [SerializeField]InventorySkillButton thisInventory;
    [SerializeField] SettingWeapon thisWeapon;
    public int thisWeaponIndex;

    [SerializeField] Sprite noneSprite;

    private void Start()
    {
    }

    void GetComponentLogic()
    {
        thisButton = GetComponent<Button>();
        thisImage = GetComponent<Image>();
    }

    private void Update()
    {
        state = thisWeapon != null ? 1 : 0;
        SetImage();
    }

    public void SetImage()
    {
        switch (state)
        {
            case 0:
                thisImage.sprite = noneSprite;
                break;
            case 1:
                thisImage.sprite = thisWeapon.StateSprite[2];
                break;
            default:
                break;
        }
    }

    public void AddLayout()
    {
        SettingUIManager.Instance.SetScrollRect(0);

        SettingUIManager.Instance.currentLayout = this;
        SettingUIManager.Instance.SetTouchValue(1);
    }

    public void SetNull()
    {
        thisInventory.thisLayout = null;

        thisWeapon = null;
        thisInventory = null;
    }

    public void SetThisButtonSkill(InventorySkillButton _thisInventory, int _weaponIndex)
    {
        GetComponentLogic();

        if (thisInventory != null)
        {
            thisInventory.SetNull();
            thisInventory = null;
        }

        thisInventory = _thisInventory;
        thisInventory.state = 2;

        thisWeapon = _thisInventory.thisWeapon;
        thisWeaponIndex = _weaponIndex;
        thisInventory.thisLayout = GetComponent<SkillLayoutButton>();

        SetImage();
    }
}
