using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgradeController : MonoBehaviour
{

    [Header("Upgrading system")]
    [SerializeField] SkillUpgradeObject Skill_Upgrade_Prefab;
    [SerializeField] List<SkillUpgradeObject> Skill_Upgrade_Object_List = new List<SkillUpgradeObject>();

    [Header("Scroll View")]
    [SerializeField] ScrollRect[] Upgrade_Scroll_View;
    [SerializeField] Button[] Upgrade_Scroll_View_Button;
    [SerializeField] Sprite[] Button_Idle;
    [SerializeField] Sprite[] Button_Selected;

    [Header("Coin")]
    [SerializeField] int Coin;
    [SerializeField] Text CoinTxt;

    void Start()
    {
        UpgradeLayoutButton(0);
        InitializeSkillUpgrade();
    }

    void Update()
    {
        CoinTxtController();
    }

    void InitializeSkillUpgrade()
    {
        foreach (var item in StatusManager.Instance.Weapon_All)
        {
            SkillUpgradeObject temp = Instantiate(Skill_Upgrade_Prefab, Upgrade_Scroll_View[0].content);
            temp.SetData(item);
            Skill_Upgrade_Object_List.Add(temp);
        }
    }

    void CoinTxtController()
    {
        CoinTxt.text = "Coin: " + Coin.ToString();
    }

    public void UpgradeLayoutButton(int n)
    {
        for (int i = 0; i < Upgrade_Scroll_View.Length; i++)
        {
            Upgrade_Scroll_View[i].gameObject.SetActive(false);
            Upgrade_Scroll_View_Button[i].image.sprite = Button_Idle[i];
        }

        Upgrade_Scroll_View[n].gameObject.SetActive(true);
        Upgrade_Scroll_View_Button[n].image.sprite = Button_Selected[n];
    }
}
