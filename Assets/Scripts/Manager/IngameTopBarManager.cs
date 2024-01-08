using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//백슬기
public class IngameTopBarManager : MonoBehaviour
{
    public UILabel playerNameTX; //플레이어 이름 표시 라벨
    public UILabel playerLVTX; //플레이어 레벨 표시 라벨
    public UIProgressBar ExpBar; //경험치바
    public UILabel ExpTX; //경험치 표시 라벨
    public UILabel potionCntTX;

    //public UILabel KeyTX; //보유 열쇠 표시 라벨
    //public UILabel GoldTX; //보유 골드 표시 라벨
    //public UILabel DiaTX; //보유 보석 표시 라벨

    void Start()
    {
        
    }

    void Update()
    {
        playerNameTX.text = CharacterDatamanager.Instance().playerName;
        playerLVTX.text = CharacterDatamanager.Instance().playerLV.ToString();
        ExpBar.value = CharacterDatamanager.Instance().Exp / CharacterDatamanager.Instance().MaxExp;
        ExpTX.text = CharacterDatamanager.Instance().Exp + "/" + CharacterDatamanager.Instance().MaxExp;
        potionCntTX.text = CharacterDatamanager.Instance().HpPotion.ToString();


        //KeyTX.text = CharacterDatamanager.Instance().Key + "/" + "30";
        //GoldTX.text = CharacterDatamanager.Instance().Gold.ToString();
        //DiaTX.text = CharacterDatamanager.Instance().Dia.ToString();
    }
}
