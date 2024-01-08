using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Diagnostics;
//using Debug = UnityEngine.Debug;

public class SystemManager : MonoBehaviour
{


    public int gem;
    public int gold;
    public int key;



    static SystemManager _instance = null;


    public static SystemManager Instance()

    {

        return _instance;

    }






    private void Awake()
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




    void Start()
    {
        gem = 0;
        gold = 0;
        key = 10;

        LoadPlayerGem();
        LoadPlayerGold();
        LoadPlayerKey();

        Debug.Log("테스트디버그입니다.");


    }


    void Update()
    {



    }





    //====================================== 잼==========================================//
    public void GetGem()
    {
        gem ++;
        Debug.Log("Gemcount : " + gem);
        SavePlayerGem();
    }

    public void SavePlayerGem()
    {
        PlayerPrefs.SetInt("GemCount", gem);
        Debug.Log("Gem저장성공 : " + gem);
    }

    public void LoadPlayerGem()
    {
        gem = PlayerPrefs.GetInt("GemCount", 0);
    }


    //====================================== 골드==========================================//
    public void GetGold()
    {
        gold ++;
        Debug.Log("Goldcount : " + gold);
        SavePlayerGold();
    }

    public void SavePlayerGold()
    {
        PlayerPrefs.SetInt("GoldCount", gold);
        Debug.Log("Gold저장성공 : " + gold);
    }

    public void LoadPlayerGold()
    {
        gold = PlayerPrefs.GetInt("GoldCount", 0);
    }



    //====================================== 열쇠==========================================//
    public void GetKey()
    {
        key++;
        Debug.Log("Keycount : " + key);
        SavePlayerKey();
    }

    public void SavePlayerKey()
    {
        PlayerPrefs.SetInt("Keycount", key);
        Debug.Log("Key저장성공 : " + key);
    }

    public void LoadPlayerKey()
    {
        key = PlayerPrefs.GetInt("Keycount", 0);
    }

}