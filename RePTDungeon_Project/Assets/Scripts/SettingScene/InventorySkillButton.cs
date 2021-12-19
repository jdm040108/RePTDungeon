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
    public int index;

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

                    if (state == 2)
                    {
                        DestroyLayoutSkill();
                    }
                    else
                    {
                        manager.skillTouchState = 1;
                        manager.selectedWeapon = thisWeapon;
                        state = 2;
                        manager.selectedInventory = this;
                    }
                    break;
                case 1:
                    if (manager.selectedWeapon != this.thisWeapon)
                    {
                        manager.skillTouchState = 0;
                        manager.selectedWeapon = this.thisWeapon;
                        manager.selectedInventory = this;
                    }
                    else
                    {
                        manager.skillTouchState = 0;
                        manager.selectedWeapon = null;
                        manager.selectedInventory = null;
                    }
                    state = 1;
                    SetImage();
                    break;
                case 2:

                    if (thisLayout != null)
                    {
                        DestroyLayoutSkill();
                    }

                    manager.SkillButtonLayout[manager.curButton].thisSkill = thisWeapon;

                    SetLayoutButton(manager.selectedLayout);
                    thisLayout = manager.selectedLayout;
                    manager.selectedLayout = null;
                    state = 2;
                    manager.skillTouchState = 0;
                    break;
                default:
                    break;
            }
        }
        SetImage();
    }

    void SetLayoutButton(SkillLayoutButton selectedLayout)
    {
        selectedLayout.thisInventory = this;
        selectedLayout.thisSkill = thisWeapon;
        selectedLayout.State = 1;
        selectedLayout.SetImage();
    }

    void DestroyLayoutSkill()
    {
        thisLayout.thisSkill = null;
        thisLayout.State = 0;
        thisLayout.SetImage();

        state = 1;
        SetImage();
    }
}
