using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SettingUIManager : Singleton<SettingUIManager>
{
    StatusManager statusManager;
    int currentCost;

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

    public List<InventorySkillButton> Inventory_Layout_Buttons = new List<InventorySkillButton>();

    [Header("Setting")]
    [SerializeField] GameObject InventoryLayout;
    [SerializeField] GameObject cur_Layout_Object;
    [SerializeField] GameObject cur_Layout_Upgrade;

    [Header("Upgrade")]
    [SerializeField] Transform Upgrade_Layout_Transform;
    [SerializeField] SkillUpgrade UpgradePrefab;
    [SerializeField] List<SkillUpgrade> Upgrade_Layout = new List<SkillUpgrade>();

    [Header("Unlock")]
    [SerializeField] GameObject UnlockObject;
    [SerializeField] Text UnlockMessage;
    string message = "해금하시겠습니까?\n가격: ";

    protected override void Awake()
    {

    }

    private void Start()
    {
        statusManager = StatusManager.Instance;
        UnlockObject.SetActive(false);
        InitializeInventoryLayout();
        SetInventoryLayout();
        SetScrollRect(0);
        InitLayout();
        InitUpgradeButton();
    }

    private void Update()
    {
        switch (_touch_state)
        {
            case 0:
                InventoryLayout.SetActive(false);
                cur_Layout_Upgrade.SetActive(true);
                cur_Layout_Object.SetActive(false);
                break;
            case 1:
                InventoryLayout.SetActive(true);
                cur_Layout_Object.SetActive(true);
                cur_Layout_Upgrade.SetActive(false);
                cur_Layout_Object.transform.position = LayoutButton[cur_layout_index].transform.position;
                break;
            default:
                break;
        }
    }

    public void UnlockMessageOn(int _cost)
    {
        currentCost = _cost;
        UnlockObject.SetActive(true);
        UnlockMessage.text = "";
        UnlockObject.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            UnlockMessage.DOText(message + _cost.ToString(), 1f);
        });
    }

    public void UnlockYes()
    {
        if(statusManager.Coin >= currentInventory.thisWeapon.upgradeCost)
        {
            UnlockExit();
            statusManager.Coin -= currentInventory.thisWeapon.upgradeCost;
            currentInventory.state = 1;
            SaveInventoryStateData();
        }
    }

    void SaveInventoryStateData()
    {
        statusManager.Inventory_Status_Index.Clear();
        foreach (var item in Inventory_Layout_Buttons)
        {
            statusManager.Inventory_Status_Index.Add(item.state);
        }
    }

    public void UnlockNo()
    {
        UnlockExit();
    }

    void UnlockExit()
    {
        UnlockObject.transform.DOLocalMoveY(-1078, 1f).SetEase(Ease.InOutBack).OnComplete(() =>
        {
            UnlockMessage.text = "";
            UnlockObject.SetActive(false);
        });
    }

    public void MoveScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    void InitUpgradeButton()
    {
        for (int i = 0; i < 8; i++)
        {
            SkillUpgrade upgrade = Instantiate(UpgradePrefab, Upgrade_Layout_Transform);
            UpgradeButtonSetData(upgrade, Inventory_Layout_Buttons[LayoutButton[i].thisWeaponIndex].thisWeapon);
            Upgrade_Layout.Add(upgrade);
        }
    }

    public void SetUpgradeButtonData()
    {
        for (int i = 0; i < 8; i++)
        {
            UpgradeButtonSetData(Upgrade_Layout[i], Inventory_Layout_Buttons[LayoutButton[i].thisWeaponIndex].thisWeapon);
        }
    }

    void UpgradeButtonSetData(SkillUpgrade _upgrade, SettingWeapon _skill)
    {
        _upgrade.SetData(_skill);
    }

    void InitLayout()
    {
        for (int i = 0; i < LayoutButton.Count; i++)
        {
            LayoutButton[i].SetThisButtonSkill(Inventory_Layout_Buttons[statusManager.Layout_Index[i]], Inventory_Layout_Buttons[statusManager.Layout_Index[i]].index);
        }
    }

    void InitializeInventoryLayout()
    {

        Skill_Common.Clear();
        foreach (var item in statusManager.Weapon_Common)
        {
            Skill_Common.Add(item);
        }

        Skill_Rare.Clear();
        foreach (var item in statusManager.Weapon_Rare)
        {
            Skill_Rare.Add(item);
        }

        Skill_VeryRare.Clear();
        foreach (var item in statusManager.Weapon_VeryRare)
        {
            Skill_VeryRare.Add(item);
        }

        Skill_Super.Clear();
        foreach (var item in statusManager.Weapon_Super)
        {
            Skill_Super.Add(item);
        }
    }

    public void SetInventoryLayout()
    {
        int index = 0;

        Inventory_Layout_Buttons.Clear();

        Inventory_Layout_Buttons_Common.Clear();
        for (int i = 0; i < Skill_Common.Count; i++)
        {
            InventorySkillButton I_temp = Instantiate(Inventory_Prefab, SkillScroll[0].content.transform);

            I_temp.SetValue(index, Skill_Common[i]);
            Inventory_Layout_Buttons_Common.Add(I_temp);
            Inventory_Layout_Buttons.Add(I_temp);

            index++;
        }

        Inventory_Layout_Buttons_Rare.Clear();
        for (int i = 0; i < Skill_Rare.Count; i++)
        {
            InventorySkillButton I_temp = Instantiate(Inventory_Prefab, SkillScroll[1].content.transform);

            I_temp.SetValue(index, Skill_Rare[i]);
            Inventory_Layout_Buttons_Rare.Add(I_temp);
            Inventory_Layout_Buttons.Add(I_temp);

            index++;
        }

        Inventory_Layout_Buttons_VeryRare.Clear();
        for (int i = 0; i < Skill_VeryRare.Count; i++)
        {
            InventorySkillButton I_temp = Instantiate(Inventory_Prefab, SkillScroll[2].content.transform);

            I_temp.SetValue(index, Skill_VeryRare[i]);
            Inventory_Layout_Buttons_VeryRare.Add(I_temp);
            Inventory_Layout_Buttons.Add(I_temp);

            index++;
        }

        Inventory_Layout_Buttons_Super.Clear();
        for (int i = 0; i < Skill_Super.Count; i++)
        {
            InventorySkillButton I_temp = Instantiate(Inventory_Prefab, SkillScroll[3].content.transform);

            I_temp.SetValue(index, Skill_Super[i]);
            Inventory_Layout_Buttons_Super.Add(I_temp);
            Inventory_Layout_Buttons.Add(I_temp);

            index++;
        }


        for (int i = 0; i < Inventory_Layout_Buttons.Count; i++)
        {
            Inventory_Layout_Buttons[i].state = statusManager.Inventory_Status_Index[i];
        }
    }

    public void SetLayoutIndex()
    {
        statusManager.Layout_Index.Clear();
        foreach (var item in LayoutButton)
        {
            statusManager.Layout_Index.Add(item.thisWeaponIndex);
        }

        statusManager.Inventory_Status_Index.Clear();
        foreach (var item in Inventory_Layout_Buttons)
        {
            statusManager.Inventory_Status_Index.Add(item.state);
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
