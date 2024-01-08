using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManagerScript : MonoBehaviour
{
    static GameManagerScript _instance = null;
    public static GameManagerScript Instance()
    {
        return _instance;
    }

    public int players;
    public GameObject[] playerObj = new GameObject[4];
    GameObject respawn = null;

    public GameObject StageSlotObj;
    public GameObject stageClearResultWindow;
    public UILabel stageNameTxt;
    public GameObject stageStartTxt;

    public UILabel playTime_Txt;
    public UILabel acquireGold_Txt;
    public UILabel mobKiiedCnt_Txt;

    public GameObject deadWindow;


    public float totalPlayTime;
    public int totalGold;
    public int totalMobKillCnt;

    public int minute;
    public int hour;


    public int _stageValue;
    public int _stageStateValue;

    public int index;
    public string chr_Name_kr;
    public string chr_Name;
    public int hp;
    public int mp;
    public float atk;
    public float def;
    public float movementSpeed;

    public bool bossClear = false;

    public int std;
    public int worldIndex;
    public int stageIndex;
    public string worldName_Kr;
    public string worldName;
    public int properLevel;
    public int stageDifficulty;
    public int rewardGold;
   
    public bool isGameover = false;
    public GameObject incontrol ;
    public GameObject gamedata;

    public bool onetime = false;



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



        //DontDestroyOnLoad(this.gameObject);


        //====================================태그로 플레이어 가져오기==================================================//


        GameObject playerOBJ = null;

        playerOBJ = GameObject.FindGameObjectWithTag("Player");

        if (playerOBJ != null)
        {
            Debug.Log("성공적으로" + playerOBJ.name + "오브젝트를 받았습니다");
        }
        else
        {
            Debug.LogError(" 해당 캐릭터의 태그를 얻는데 실패했습니다.");
        }
        //====================================태그로 플레이어 가져오기==================================================//
    }
    
    

    void Start()
    {
        

        StageSlotObj = GameObject.Find("UserClearInfoManager");
       

        LoadNowStageValue();

        StartCoroutine(StageStartWait());

        stageNameTxt.text = worldIndex + "." + worldName_Kr + "(" + stageIndex + ")";

        //_stageValue = StageSlotScript.Instance().stageValue;

        TotalGold();
        Debug.Log("TotalGold" + totalGold);


        if (CharacterSelecteManager.Instance().playerIndex == 0)
        {
            CharacterDatamanager.Instance().LoadCharaterData(0);


            index = CharacterDatamanager.Instance().index;
            chr_Name_kr = CharacterDatamanager.Instance().chr_Name_kr;
            chr_Name = CharacterDatamanager.Instance().chr_Name;
            hp = CharacterDatamanager.Instance().hp;
            mp = CharacterDatamanager.Instance().mp;
            atk = CharacterDatamanager.Instance().atk;
            def = CharacterDatamanager.Instance().def;
            movementSpeed = CharacterDatamanager.Instance().movementSpeed;

            
        }

        if (CharacterSelecteManager.Instance().playerIndex == 1)
        {
            CharacterDatamanager.Instance().LoadCharaterData(1);


            index = CharacterDatamanager.Instance().index;
            chr_Name_kr = CharacterDatamanager.Instance().chr_Name_kr;
            chr_Name = CharacterDatamanager.Instance().chr_Name;
            hp = CharacterDatamanager.Instance().hp;
            mp = CharacterDatamanager.Instance().mp;
            atk = CharacterDatamanager.Instance().atk;
            def = CharacterDatamanager.Instance().def;
            movementSpeed = CharacterDatamanager.Instance().movementSpeed;
        }

        if (CharacterSelecteManager.Instance().playerIndex == 2)
        {
            CharacterDatamanager.Instance().LoadCharaterData(2);


            index = CharacterDatamanager.Instance().index;
            chr_Name_kr = CharacterDatamanager.Instance().chr_Name_kr;
            chr_Name = CharacterDatamanager.Instance().chr_Name;
            hp = CharacterDatamanager.Instance().hp;
            mp = CharacterDatamanager.Instance().mp;
            atk = CharacterDatamanager.Instance().atk;
            def = CharacterDatamanager.Instance().def;
            movementSpeed = CharacterDatamanager.Instance().movementSpeed;
        }

        if (CharacterSelecteManager.Instance().playerIndex == 3)
        {
            CharacterDatamanager.Instance().LoadCharaterData(3);


            index = CharacterDatamanager.Instance().index;
            chr_Name_kr = CharacterDatamanager.Instance().chr_Name_kr;
            chr_Name = CharacterDatamanager.Instance().chr_Name;
            hp = CharacterDatamanager.Instance().hp;
            mp = CharacterDatamanager.Instance().mp;
            atk = CharacterDatamanager.Instance().atk;
            def = CharacterDatamanager.Instance().def;
            movementSpeed = CharacterDatamanager.Instance().movementSpeed;
        }


        players = CharacterSelecteManager.Instance().playerIndex;
       
        Debug.Log("playerIndex : " + players);

        respawn = GameObject.FindGameObjectWithTag("Respawn");

        // 위치를 위한 오브젝트
        for (int i = 0; i < 4; i++)
            if (players == i) Instantiate(playerObj[i], respawn.transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        //if (players == i) Instantiate(playerObj[i], respawn.transform.position, Quaternion.identity);
        gamedata = GameObject.Find("CharacterDatamanager");


    }

    void Update()
    {

        //=======================스테이지 클리어 타임 체크=================================================//
        if(bossClear == false)
        {
            totalPlayTime += Time.deltaTime;
            if(totalPlayTime >= 60)
            {
                totalPlayTime = 0;

                minute += 1;

                if (minute >= 60)
                {
                    minute = 0;
                    hour += 1;
                }

            }

            playTime_Txt.text = hour + "시간" + minute +"분" + +Mathf.Round(totalPlayTime) +"초" ;
            
        }


       if(bossClear == true)
       {
            totalPlayTime = Time.deltaTime;

        }

        //=======================스테이지 클리어 타임 체크=================================================//


        mobKiiedCnt_Txt.text = "" + totalMobKillCnt;
        acquireGold_Txt.text = "" + totalGold;


        if(isGameover == true)
        {
            incontrol.SetActive(false);
            StartCoroutine(PlayerDeadWait());
        }

        

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           
            StageDefaultValueChager();
            Debug.Log("스테이지스테이트밸류값_기본값");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            
            StageClearValueChager();
            Debug.Log("스테이지스테이트밸류값_클리어값");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
           
            StageDisableValueChager();
            Debug.Log("스테이지스테이트밸류값_사용불가값");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
           
            MobKillCnt();
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
           
            AddGold();

        }

        //=======================스테이지 클리어 실행=================================================//
        if (bossClear == true)
        {
             StartCoroutine(StageClearBossWait());

            if (!onetime)
            {
                SaveTotalGold();
                onetime = true;
            }

        }
        //=======================스테이지 클리어 실행=================================================//
    }

    public void LoadNowStageValue()
    {
        _stageValue = PlayerPrefs.GetInt("StageValue", _stageValue);
        std = _stageValue;

        LoadStageInfoData(std);        
        Debug.Log("StageValue : " + _stageValue);
    }


    public void StageDefaultValueChager()
    {
        _stageStateValue = StageSlotObj.GetComponent<UserClearInfoManager>().stageClearValue[_stageValue] = 0;

        UserClearInfoManager.Instance().SaveStageClearValue();



    }

    public void StageClearValueChager()
    {
        _stageStateValue = StageSlotObj.GetComponent<UserClearInfoManager>().stageClearValue[_stageValue] = 1;

        if (StageSlotObj.GetComponent<UserClearInfoManager>().stageClearValue[_stageValue + 1] == 2)
        {
            _stageStateValue = StageSlotObj.GetComponent<UserClearInfoManager>().stageClearValue[_stageValue + 1] = 0;
            
        }

        if (_stageStateValue >= 59)
        {
            _stageStateValue = 59;
        }

        UserClearInfoManager.Instance().SaveStageClearValue();
    }

    public void StageDisableValueChager()
    {
        _stageStateValue = StageSlotObj.GetComponent<UserClearInfoManager>().stageClearValue[_stageValue] = 2;
        UserClearInfoManager.Instance().SaveStageClearValue();
    }


    public void LoadStageInfoData(int std)
    {
        WorldSelecterManager.Instance().LoadWorldData(std);

        index = WorldSelecterManager.Instance().index;
        worldIndex = WorldSelecterManager.Instance().worldIndex;
        stageIndex = WorldSelecterManager.Instance().stageIndex;
        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
        worldName = WorldSelecterManager.Instance().worldName;
        properLevel = WorldSelecterManager.Instance().properLevel;
        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
        rewardGold = WorldSelecterManager.Instance().rewardGold;
        //spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
        //spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
        //spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
        //spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
        //spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
        //spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
        //spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
        //spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
        //spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
        //spawnMob09 = WorldSelecterManager.Instance().spawnMob09;
        //loadSceneNo = WorldSelecterManager.Instance().loadSceneNo;

    }



    IEnumerator StageStartWait()
    {
        int i = 0;
        while (i < 1)
        {

            yield return new WaitForSeconds(1f);

            stageStartTxt.SetActive(true);


            yield return new WaitForSeconds(5f);

            stageStartTxt.SetActive(false);

            i++;
        }
    }


    IEnumerator StageClearBossWait()
    {
        int i = 0;
        while (i < 1)
        {
            StageClearValueChager();

            yield return new WaitForSeconds(2f);
           
            stageClearResultWindow.SetActive(true);

           

            i++;
            
        }
    }


    IEnumerator PlayerDeadWait()
    {
        int i = 0;
        while (i < 1)
        {
           
            yield return new WaitForSeconds(2f);

            deadWindow.SetActive(true);

            i++;

        }
    }



    public void MobKillCnt()
    {
        totalMobKillCnt += 1;
        Debug.Log("누적킬카운트 : " + totalMobKillCnt);
    }

    public void AddGold()
    {
        totalGold += 30;
        Debug.Log("누적획득골드 : " + totalGold);
        
    }



    public void TotalGold()
    {
        totalGold += rewardGold;
        
    }



    public void OpenDeadWindow()
    {
        deadWindow.SetActive(true);
    }

    public void CloseDeadWindow()
    {
        deadWindow.SetActive(false);
    }


    public void SaveTotalGold()
    {
        gamedata.GetComponent<CharacterDatamanager>().Gold += totalGold;
        gamedata.GetComponent<CharacterDatamanager>().SaveGold();
    }
}