using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySkillButton : MonoBehaviour
{

    Button thisButton;
    Image thisImage;

    public SettingWeapon thisWeapon;
    public SkillLayoutButton thisLayout;
    public int index;

    public int state;

    private void Update()
    {
        SetImage();
    }

    public void GetComponentFromThisObject()
    {
        thisButton = GetComponent<Button>();
        thisImage = GetComponent<Image>();
    }

    public void SetNull()
    {
        thisLayout = null;
    }

    public void SetValue(int _index, SettingWeapon _thisWeapon)
    {
        GetComponentFromThisObject();
        index = _index;
        thisWeapon = _thisWeapon;
        SetImage();
    }

    public void SetImage()
    {
        thisImage.sprite = thisWeapon.StateSprite[state];
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
            thisLayout.SetThisButtonSkill(this.GetComponent<InventorySkillButton>(), index);

            SettingUIManager.Instance.touch_state = 0;
        }

        SetImage();

        SettingUIManager.Instance.SetLayoutIndex();
    }
}
