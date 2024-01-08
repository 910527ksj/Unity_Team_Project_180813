using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
//정승완, 백슬기
public class CharacterDatamanager : MonoBehaviour
{
    static CharacterDatamanager _instance = null;
    public static CharacterDatamanager Instance()
    {
        return _instance;
    }

    public TextAsset jsonData;

    public int index;
    public string chr_Name_kr;
    public string chr_Name;
    public int hp;
    public int mp;
    public float atk;
    public float def;
    public float movementSpeed;

    //
    public string playerName; //플레이어 이름

    public TextAsset EXP_Table; //레벨 디자인 테이블
    public int playerLV; //플레이어 레벨
    public float Exp; //현재경험치(경험치바용)
    public float MaxExp; //최대경험치(경험치바용)

    public int Key; //열쇠
    public int Gold; //골드
    public int Dia; //보석
    

    public int HpPotion; //체력물약
    public int MpPotion; //체력물약
    //public int RandomBox; //랜덤박스

    public GameObject levelUp;
  

    //mobExp

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);


      
    }

    private void Start()
    {
       
        GameObject.Find("LVUP");
    }

    //
    void Update()
    {
        playerName = PlayerPrefs.GetString("playerName");
        playerLV = PlayerPrefs.GetInt("playerLV", 1);
        Exp = PlayerPrefs.GetFloat("Exp");

        Key = PlayerPrefs.GetInt("Key", 30);
        Gold = PlayerPrefs.GetInt("Gold", 1000);
        Dia = PlayerPrefs.GetInt("Dia", 100);

        LevelStateLoad();
       

        if (Exp >= MaxExp)
        {
            playerLV += 1;
            PlayerPrefs.SetInt("playerLV", playerLV);
            Exp = 0;
            PlayerPrefs.SetFloat("Exp", Exp);

            StartCoroutine(PlayerLevelUpWait());

        }

        HpPotion = PlayerPrefs.GetInt("HpPotion");
        MpPotion = PlayerPrefs.GetInt("MpPotion");
        //RandomBox = PlayerPrefs.GetInt("RandomBox");


    }
    void LevelStateLoad() //레벨 테이블 정보 불러오기
    {
        var LevelData = JSON.Parse(EXP_Table.text);

        for (int i = 0; i < LevelData.Count; i++)
        {
            if (playerLV == LevelData[i]["level"])
                MaxExp = LevelData[i]["requiredEXP"];
        }

        
    }
    //

    public void LoadCharaterData(int pChar)
    {
        var DATA = JSON.Parse(jsonData.text);

        index = (int)DATA[pChar]["Index"];
        chr_Name_kr = (string)DATA[pChar]["Chr_Name_kr"];
        chr_Name = (string)DATA[pChar]["Chr_Name"];
        hp = (int)DATA[pChar]["HP"] + (playerLV * 30);
        mp = (int)DATA[pChar]["MP"] + (playerLV * 10);
        atk = (float)DATA[pChar]["ATK"] + (playerLV * 3) + InventoryManagerScript.Instance().total_AT_value;
        def = (float)DATA[pChar]["DEF"] + InventoryManagerScript.Instance().total_DF_value;
        movementSpeed = (float)DATA[pChar]["MovementSpeed"];
    }

    public void SaveEXP()
    {
        PlayerPrefs.SetFloat("Exp", Exp);
    }
    public void SaveGold()
    {
        PlayerPrefs.SetInt("Gold", Gold);
    }


    public void SaveHpPotion()
    {
        if(HpPotion > 0)
        {
            HpPotion -= 1;
            PlayerPrefs.SetInt("HpPotion", HpPotion);
            //playerController.GetComponent<PlayerController>().hp += 50;
            Debug.Log("체력물약씀");
        }
       

    }

    public void SaveMpPotion()
    {
        if(MpPotion > 0)
        {
            MpPotion -= 1;
            PlayerPrefs.SetInt("MpPotion", MpPotion);
            //playerController.GetComponent<PlayerController>().mp += 50;
            Debug.Log("마나물약씀");

        }
       
    }

    //public void SaveRandomBox()
    //{
    //    if (RandomBox > 0)
    //    {
    //        RandomBox -= 1;
    //        PlayerPrefs.SetInt("RandomBox", RandomBox);
    //        //playerController.GetComponent<PlayerController>().hp += 50;
    //        Debug.Log("체력물약씀");
    //    }


    //}


    IEnumerator PlayerLevelUpWait()
    {
        int i = 0;
        while (i < 1)
        {
            
            yield return new WaitForSeconds(0f);

            levelUp.SetActive(true);

            yield return new WaitForSeconds(2f);

            levelUp.SetActive(false);

            i++;

        }
    }

}