using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySkillButton : MonoBehaviour
{
    SettingUIManager manager;
    public SettingWeapon thisWeapon;

    public int state; //0: locked, 1: unlocked, 2: setted
    int touchState;
    Image image;

    public SkillLayoutButton thisLayout;

    void Start()
    {
        manager = SettingUIManager.Instance;
        image = GetComponent<Image>();
        SetImage();
    }

    void Update()
    {
        touchState = manager.skillTouchState;
    }

    public void SetImage()
    {
        image.sprite = thisWeapon.StateSprite[state];
    }

    public void TouchThis()
    {
        if (state != 0)
        {
            switch (touchState)
            {
                case 0:
                    manager.skillTouchState = 1;
                    manager.selectedWeapon = thisWeapon;
                    state = 2;
                    manager.selectedInventory = this;
                    break;
                case 1:
                    if(manager.selectedWeapon != this.thisWeapon)
                    {
                        manager.skillTouchState = 0;
                        manager.selectedWeapon = this.thisWeapon;
                        manager.selectedInventory = this;
                        state = 1;
                    }
                    else
                    {
                        manager.skillTouchState = 0;
                        state = 0;
                        manager.selectedWeapon = null;
                        manager.selectedInventory = null;
                    }
                    SetImage();
                    break;
                case 2:
                    manager.SkillButtonLayout[manager.curButton].thisSkill = thisWeapon;
                    manager.selectedLayout.thisInventory = this;
                    manager.selectedLayout = null;
                    state = 2;
                    break;
                default:
                    break;
            }
        }
        SetImage();
    }
}
