using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLayoutButton : MonoBehaviour
{
    public int State; // 0: no skill available, 1: skill available
    public SettingWeapon thisSkill;
    public Sprite noSkill;
    Image icon;

    SettingUIManager uiManager;
    int touchState;

    public InventorySkillButton thisInventory;

    void Start()
    {
        icon = GetComponent<Image>();
        uiManager = SettingUIManager.Instance;
        SetImage();
    }

    void Update()
    {
        touchState = uiManager.skillTouchState;
    }

    public void SetImage()
    {
        switch (State)
        {
            case 0:
                icon.sprite = noSkill;
                break;
            case 1:
                icon.sprite = thisSkill.StateSprite[1];
                break;
            default:
                break;
        }
    }

    public void TouchThis(int n)
    {
        switch (touchState)
        {
            case 0:
                State = 0;

                thisSkill = null;
                uiManager.skillTouchState = 2;
                SetImage();
                uiManager.selectedLayout = this;
                break;
            case 1:
                SetThisSkill(uiManager.selectedWeapon);
                State = 1;
                SetImage();
                uiManager.selectedInventory.thisLayout = this;
                uiManager.SetNull();
                break;
            case 2:
                if (uiManager.SkillButtonLayout[uiManager.curButton] != this)
                {
                    InitialThisState(2);
                }
                else
                {
                    InitialThisState(0);
                }
                break;
            default:
                break;
        }
        uiManager.curButton = n;
        uiManager.SetSkillImage();
    }



    void SetThisSkill(SettingWeapon _skill)
    {
        thisSkill = _skill;
        uiManager.skillTouchState = 0;
        uiManager.curButton = -1;
    }

    void InitialThisState(int _touchState)
    {
        State = 0;
        uiManager.skillTouchState = _touchState;
        uiManager.curButton = -1;
        uiManager.SetSkillImage();
        uiManager.selectedLayout = null;
    }
}
