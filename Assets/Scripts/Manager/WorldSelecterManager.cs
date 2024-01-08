using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class WorldSelecterManager : MonoBehaviour
{
    static WorldSelecterManager _instance = null;

    public static WorldSelecterManager Instance()
    {
        return _instance;
    }


    public TextAsset jsonData;

    public int _worldIndex;

    public int _lobbyStateIndex;

    public int index;
    public int worldIndex;
    public int stageIndex;
    public string worldName_Kr;
    public string worldName;
    public int properLevel;
    public int stageDifficulty;
    public int rewardGold;
    public int spawnMob00;
    public int spawnMob01;
    public int spawnMob02;
    public int spawnMob03;
    public int spawnMob04;
    public int spawnMob05;
    public int spawnMob06;
    public int spawnMob07;
    public int spawnMob08;
    public int spawnMob09;
    public int loadSceneNo;

    public GameObject worldImage01;
    public GameObject worldImage02;
    public GameObject worldImage03;
    public GameObject worldImage04;
    public GameObject worldImage05;
    public GameObject worldImage06;



    public GameObject worldName_Text01;
    public GameObject worldName_Text02;
    public GameObject worldName_Text03;
    public GameObject worldName_Text04;
    public GameObject worldName_Text05;
    public GameObject worldName_Text06;



    public int stageIndex_
    {
        get
        {
            return _worldIndex;
        }
        set
        {
            _worldIndex = value;
        }

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

       //DontDestroyOnLoad(this.gameObject);

    }


    void Start()
    {
        //PlayerPrefs.DeleteAll();
        LoadWorldIndex();
        StageIndexChanger();

        
        //Debug.Log("worldIndex : " + _worldIndex);

    }


    void Update()
    {


    }


    public void LoadWorldData(int world)
    {
        var DATA = JSON.Parse(jsonData.text);

        index = (int)DATA[world]["Index"];
        worldIndex = (int)DATA[world]["World_Index"];
        stageIndex = (int)DATA[world]["Stage_Index"];
        worldName_Kr = (string)DATA[world]["WorldName_Kr"];
        worldName = (string)DATA[world]["WorldName"];
        properLevel = (int)DATA[world]["ProperLevel"];
        stageDifficulty = (int)DATA[world]["StageDifficulty"];
        rewardGold = (int)DATA[world]["RewardGold"];
        spawnMob00 = (int)DATA[world]["SpawnMob00"];
        spawnMob01 = (int)DATA[world]["SpawnMob01"];
        spawnMob02 = (int)DATA[world]["SpawnMob02"];
        spawnMob03 = (int)DATA[world]["SpawnMob03"];
        spawnMob04 = (int)DATA[world]["SpawnMob04"];
        spawnMob05 = (int)DATA[world]["SpawnMob05"];
        spawnMob06 = (int)DATA[world]["SpawnMob06"];
        spawnMob07 = (int)DATA[world]["SpawnMob07"];
        spawnMob08 = (int)DATA[world]["SpawnMob08"];
        spawnMob09 = (int)DATA[world]["SpawnMob09"];
        loadSceneNo = (int)DATA[world]["LoadSceneNo"];
    }





    public void StageSelectRightBtn()
    {

        if (_worldIndex >= 5)
        {

            _worldIndex = 5;
        }
        else
        {
            _worldIndex += 1;
        }


        StageIndexChanger();
        Debug.Log("worldIndex : " + _worldIndex);


        SaveWorldIndex();


    }

    public void StageSelectLeftBtn()
    {

        if (_worldIndex <= 0)
        {
            _worldIndex = 0;
        }
        else
        {
            _worldIndex -= 1;
        }




        StageIndexChanger();
        Debug.Log("worldIndex : " + _worldIndex);
        //Debug.Log("curstageIndex : " + curstageIndex);

        SaveWorldIndex();
    }


    void StageIndexChanger()
    {
        //============================스테이지 선택=================================================//

        if (_worldIndex == 0)
        {
            //Instantiate(Lobbyplayer01, transform.position, transform.rotation);

            worldImage01.SetActive(true);
            worldImage02.SetActive(false);
            worldImage03.SetActive(false);
            worldImage04.SetActive(false);
            worldImage05.SetActive(false);
            worldImage06.SetActive(false);

            worldName_Text01.SetActive(true);
            worldName_Text02.SetActive(false);
            worldName_Text03.SetActive(false);
            worldName_Text04.SetActive(false);
            worldName_Text05.SetActive(false);
            worldName_Text06.SetActive(false);
        }


        if (_worldIndex == 1)
        {
            //Instantiate(Lobbyplayer02, transform.position, transform.rotation);

            worldImage01.SetActive(false);
            worldImage02.SetActive(true);
            worldImage03.SetActive(false);
            worldImage04.SetActive(false);
            worldImage05.SetActive(false);
            worldImage06.SetActive(false);

            worldName_Text01.SetActive(false);
            worldName_Text02.SetActive(true);
            worldName_Text03.SetActive(false);
            worldName_Text04.SetActive(false);
            worldName_Text05.SetActive(false);
            worldName_Text06.SetActive(false);
        }


        if (_worldIndex == 2)
        {
            //Instantiate(Lobbyplayer03, transform.position, transform.rotation);
            worldImage01.SetActive(false);
            worldImage02.SetActive(false);
            worldImage03.SetActive(true);
            worldImage04.SetActive(false);
            worldImage05.SetActive(false);
            worldImage06.SetActive(false);

            worldName_Text01.SetActive(false);
            worldName_Text02.SetActive(false);
            worldName_Text03.SetActive(true);
            worldName_Text04.SetActive(false);
            worldName_Text05.SetActive(false);
            worldName_Text06.SetActive(false);

        }


        if (_worldIndex == 3)
        {
            //Instantiate(Lobbyplayer04, transform.position, transform.rotation);
            worldImage01.SetActive(false);
            worldImage02.SetActive(false);
            worldImage03.SetActive(false);
            worldImage04.SetActive(true);
            worldImage05.SetActive(false);
            worldImage06.SetActive(false);

            worldName_Text01.SetActive(false);
            worldName_Text02.SetActive(false);
            worldName_Text03.SetActive(false);
            worldName_Text04.SetActive(true);
            worldName_Text05.SetActive(false);
            worldName_Text06.SetActive(false);
        }

        if (_worldIndex == 4)
        {
            //Instantiate(Lobbyplayer04, transform.position, transform.rotation);
            worldImage01.SetActive(false);
            worldImage02.SetActive(false);
            worldImage03.SetActive(false);
            worldImage04.SetActive(false);
            worldImage05.SetActive(true);
            worldImage06.SetActive(false);

            worldName_Text01.SetActive(false);
            worldName_Text02.SetActive(false);
            worldName_Text03.SetActive(false);
            worldName_Text04.SetActive(false);
            worldName_Text05.SetActive(true);
            worldName_Text06.SetActive(false);
        }

        if (_worldIndex == 5)
        {
            //Instantiate(Lobbyplayer04, transform.position, transform.rotation);
            worldImage01.SetActive(false);
            worldImage02.SetActive(false);
            worldImage03.SetActive(false);
            worldImage04.SetActive(false);
            worldImage05.SetActive(false);
            worldImage06.SetActive(true);

            worldName_Text01.SetActive(false);
            worldName_Text02.SetActive(false);
            worldName_Text03.SetActive(false);
            worldName_Text04.SetActive(false);
            worldName_Text05.SetActive(false);
            worldName_Text06.SetActive(true);

        }

        if (_worldIndex < -5)
        {
            _worldIndex = 5;
        }


    }



    void SaveWorldIndex()
    {

        PlayerPrefs.SetInt("WorldIndex", _worldIndex);
        Debug.Log("World_Index저장성공 : " + _worldIndex);
    }


    

    


    //void LoadWorldIndex()

    //{

    //    _worldIndex = PlayerPrefs.GetInt("WorldIndex", 0);

    //}


    void LoadWorldIndex()
    {

        _worldIndex = PlayerPrefs.GetInt("WorldIndex", _worldIndex);
        //Debug.Log("_worldIndex로드성공 : " + _worldIndex);


        if (_worldIndex == 0 || _worldIndex == null)
        {
            _worldIndex = 0;
            worldImage01.SetActive(true);
        }
        if (_worldIndex == 1)
        {
            _worldIndex = 1;
            worldImage02.SetActive(true);
        }
        if (_worldIndex == 2)
        {
            _worldIndex = 2;
            worldImage03.SetActive(true);
        }
        if (_worldIndex == 3)
        {
            _worldIndex = 3;
            worldImage04.SetActive(true);

        }
        if (_worldIndex == 4)
        {
            _worldIndex = 4;
            worldImage05.SetActive(true);

        }
        if (_worldIndex == 5)
        {
            _worldIndex = 5;
            worldImage06.SetActive(true);

        }




    }


}