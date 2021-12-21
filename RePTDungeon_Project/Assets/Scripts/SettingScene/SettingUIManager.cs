using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUIManager : Singleton<SettingUIManager>
{

    [Header("Layout")]
    public List<SkillLayoutButton> LayoutButton = new List<SkillLayoutButton>();
    public int cur_layout_index;

    [Header("Item")]
    public List<SettingWeapon> Skill_Common;
    public List<SettingWeapon> Skill_Rare;
    public List<SettingWeapon> Skill_VeryRare;
    public List<SettingWeapon> Skill_Super;

    [Header("Scroll Rect")]
    [SerializeField] ScrollRect[] SkillScroll;

    [Header("ScrollRect Buttons")]
    [SerializeField] Button[] SkillScroll_Button;
    [SerializeField] Sprite[] SkillScroll_Button_IdleSprite;
    [SerializeField] Sprite[] SkillScroll_Button_SelectedSprite;
  
    [Header("Inventory Select")]
    [SerializeField] int _touch_state;
    public int touch_state //0: unselected, 1: selected
    {
        get => _touch_state;
        set
        {
            _touch_state = value;
        }
    }

    [Header("Current Selected")]
    public SkillLayoutButton currentLayout;
    public InventorySkillButton currentInventory;

    [Header("Inventory")]
    public InventorySkillButton Inventory_Prefab;
    public List<InventorySkillButton> Inventory_Layout_Buttons_Common = new List<InventorySkillButton>();
    public List<InventorySkillButton> Inventory_Layout_Buttons_Rare = new List<InventorySkillButton>();
    public List<InventorySkillButton> Inventory_Layout_Buttons_VeryRare = new List<InventorySkillButton>();
    public List<InventorySkillButton> Inventory_Layout_Buttons_Super = new List<InventorySkillButton>();

    [Header("Setting")]
    [SerializeField] GameObject InventoryLayout;
    [SerializeField] GameObject cur_Layout_Object;

    protected override void Awake()
    {
        
    }

    private void Start()
    {
        SetInventoryLayout();
        SetScrollRect(0);
    }

    private void Update()
    {
        switch (_touch_state)
        {
            case 0:
                InventoryLayout.SetActive(false);
                cur_Layout_Object.SetActive(false);
                break;
            case 1:
                InventoryLayout.SetActive(true);
                cur_Layout_Object.SetActive(true);
                cur_Layout_Object.transform.position = LayoutButton[cur_layout_index].transform.position;
                break;
            default:
                break;
        }
    }

    public void SetInventoryLayout()
    {
        int index = 0;

        Inventory_Layout_Buttons_Common.Clear();
        for (int i = 0; i < Skill_Common.Count; i++)
        {
            InventorySkillButton I_temp = Instantiate(Inventory_Prefab, SkillScroll[0].content.transform);

            I_temp.state = 1;
            I_temp.SetValue(index, Skill_Common[i]);
            Inventory_Layout_Buttons_Common.Add(I_temp);


            index++;
        }

        Inventory_Layout_Buttons_Rare.Clear();
        for (int i = 0; i < Inventory_Layout_Buttons_Rare.Count; i++)
        {
            InventorySkillButton I_temp = Instantiate(Inventory_Prefab, SkillScroll[1].content.transform);
            I_temp.index = index;
            Inventory_Layout_Buttons_Rare.Add(I_temp);
            Inventory_Layout_Buttons_Rare[i].thisWeapon = Skill_Rare[i];
            index++;
        }

        Inventory_Layout_Buttons_VeryRare.Clear();
        for (int i = 0; i < Inventory_Layout_Buttons_VeryRare.Count; i++)
        {
            InventorySkillButton I_temp = Instantiate(Inventory_Prefab, SkillScroll[2].content.transform);
            I_temp.index = index;
            Inventory_Layout_Buttons_VeryRare.Add(I_temp);
            Inventory_Layout_Buttons_VeryRare[i].thisWeapon = Skill_VeryRare[i];
            index++;
        }

        Inventory_Layout_Buttons_Super.Clear();
        for (int i = 0; i < Inventory_Layout_Buttons_Super.Count; i++)
        {
            InventorySkillButton I_temp = Instantiate(Inventory_Prefab, SkillScroll[2].content.transform);
            I_temp.index = index;
            Inventory_Layout_Buttons_Super.Add(I_temp);
            Inventory_Layout_Buttons_Super[i].thisWeapon = Skill_Super[i];
            index++;
        }
    }

    /// <summary>
    /// 0: touch non, 1: touch able
    /// </summary>
    /// <param name="n"></param>
    public void SetTouchValue(int n)
    {
        touch_state = n;
    }

    public void SetScrollRect(int n)
    {
        for (int i = 0; i < SkillScroll.Length; i++)
        {
            SkillScroll[i].gameObject.SetActive(false);
            SkillScroll_Button[i].image.sprite = SkillScroll_Button_IdleSprite[i];
        }

        SkillScroll[n].gameObject.SetActive(true);
        SkillScroll_Button[n].image.sprite = SkillScroll_Button_SelectedSprite[n];

    }

    public void SelectLayout(int n)
    {
        cur_layout_index = n;
    }
}
