using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLayoutButton : MonoBehaviour
{
    Button thisButton;
    public int state = 0;
    InventorySkillButton thisInventory;
    SettingWeapon thisWeapon;

    [SerializeField] Sprite noneSprite;

    private void Start()
    {
        thisButton = GetComponent<Button>();
    }

    public void SetImage()
    {
        switch (state)
        {
            case 0:
                thisButton.image.sprite = noneSprite;
                break;
            case 1:
                thisButton.image.sprite = thisWeapon.StateSprite[2];
                break;
            default:
                break;
        }
    }

    public void AddLayout()
    {
        SettingUIManager.Instance.currentLayout = this;
        SettingUIManager.Instance.SetTouchValue(1);
    }

    public void SetNull()
    {
        thisWeapon = null;
        thisInventory = null;
    }

    public void SetThisButtonSkill(InventorySkillButton _thisInventory)
    {
        thisInventory = _thisInventory;
        thisWeapon = _thisInventory.thisWeapon;
    }
}
