using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySkillButton : MonoBehaviour
{

    Button thisButton;

    public SettingWeapon thisWeapon;
    public SkillLayoutButton thisLayout;
    public int index;

    public int state;

    private void Start()
    {
        thisButton = GetComponent<Button>();
    }

    public void SetImage()
    {
        thisButton.image.sprite = thisWeapon.StateSprite[state];
    }

    public void SetLayoutWeapon()
    {
        if(SettingUIManager.Instance.touch_state == 1)
        {
            if(thisLayout != null)
            {
                thisLayout.SetNull();
                thisLayout = null;
            }

            thisLayout = SettingUIManager.Instance.currentLayout;
            thisLayout.SetThisButtonSkill(this);

            SettingUIManager.Instance.touch_state = 0;
        }

        SetImage();
    }
}
