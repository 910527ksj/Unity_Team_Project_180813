using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//백슬기
public class ShopManager : MonoBehaviour
{
    public GameObject Shop;
    public GameObject ShopSystemPop;
    public UILabel ShopSystemTX;

    public int ItemNum;
    //ItemNum 번호에 따른 아이템명
    //[1 : Key] [2 : Gold] [3 : Dia] [4 : HpPotion] [5 : MpPotion] 

    public void ShopOn()
    {
        Shop.SetActive(true);
    }
    public void ShopOff()
    {
        Shop.SetActive(false);
    }

    public void KeyItemClick()
    {
        ItemNum = 1;
        ShopSystemPop.SetActive(true);
        ShopSystemTX.text = "선택하신 [열쇠] 상품을\n정말로 구매하시겠습니까?";
    }
    public void GoldItemClick()
    {
        ItemNum = 2;
        ShopSystemPop.SetActive(true);
        ShopSystemTX.text = "선택하신 [골드] 상품을\n정말로 구매하시겠습니까?";
    }
    public void DiaItemClick()
    {
        ItemNum = 3;
        ShopSystemPop.SetActive(true);
        ShopSystemTX.text = "선택하신 [보석] 상품을\n정말로 구매하시겠습니까?\n(주의! 실제로 결제될 수 있습니다.)";
        
    }
    public void HpPotionItemClick()
    {
        ItemNum = 4;
        ShopSystemPop.SetActive(true);
        ShopSystemTX.text = "선택하신 [체력물약] 상품을\n정말로 구매하시겠습니까?";
    }
    public void MpPotionItemClick()
    {
        ItemNum = 5;
        ShopSystemPop.SetActive(true);
        ShopSystemTX.text = "선택하신 [기력물약] 상품을\n정말로 구매하시겠습니까?";
    }
    public void RandomBoxClick()
    {
        ItemNum = 6;
        ShopSystemPop.SetActive(true);
        ShopSystemTX.text = "선택하신 [랜덤박스] 상품을\n정말로 구매하시겠습니까?";
    }

    public void BuyItem()
    {
        if (ItemNum == 1)
        {
            CharacterDatamanager.Instance().Key += 100;
            PlayerPrefs.SetInt("Key", CharacterDatamanager.Instance().Key);
            CharacterDatamanager.Instance().Dia -= 100;
            PlayerPrefs.SetInt("Dia", CharacterDatamanager.Instance().Dia);
        }
        if (ItemNum == 2)
        {
            CharacterDatamanager.Instance().Gold += 100;
            PlayerPrefs.SetInt("Gold", CharacterDatamanager.Instance().Gold);
            CharacterDatamanager.Instance().Dia -= 100;
            PlayerPrefs.SetInt("Dia", CharacterDatamanager.Instance().Dia);
        }
        if (ItemNum == 3)
        {
            CharacterDatamanager.Instance().Dia += 100;
            PlayerPrefs.SetInt("Dia", CharacterDatamanager.Instance().Dia);
            //현금 1000원 결제
            IAPManager.Instance().BuyConsumable01();
        }
        if (ItemNum == 4)
        {
            CharacterDatamanager.Instance().HpPotion += 100;
            PlayerPrefs.SetInt("HpPotion", CharacterDatamanager.Instance().HpPotion);
            CharacterDatamanager.Instance().Dia -= 100;
            PlayerPrefs.SetInt("Dia", CharacterDatamanager.Instance().Dia);
        }
        if (ItemNum == 5)
        {
            CharacterDatamanager.Instance().MpPotion += 100;
            PlayerPrefs.SetInt("MpPotion", CharacterDatamanager.Instance().MpPotion);
            CharacterDatamanager.Instance().Dia -= 100;
            PlayerPrefs.SetInt("Dia", CharacterDatamanager.Instance().Dia);
        }
        if (ItemNum == 6)
        {
            //CharacterDatamanager.Instance().RandomBox += 1;
            InventoryManagerScript.Instance().TestRandomBoxBtn();
            //PlayerPrefs.SetInt("RandomBox", CharacterDatamanager.Instance().RandomBox);
            CharacterDatamanager.Instance().Dia -= 10;
            PlayerPrefs.SetInt("Dia", CharacterDatamanager.Instance().Dia);
        }

        ShopSystemPop.SetActive(false);
    }
    public void BuyCancel()
    {
        ShopSystemPop.SetActive(false);
    }
}
