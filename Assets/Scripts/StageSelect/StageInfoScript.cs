using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageInfoScript : MonoBehaviour
{
    static StageInfoScript _instance = null;

    public static StageInfoScript Instance()
    {
        return _instance;
    }

    public GameObject popWindow;


    public int std;
    public int _stageValue;
    //public int  lsn;

   
    public UILabel worldName_TXT;
   //public UILabel stageNo_TXT;
    public UILabel level_TXT;
    public UILabel properLevel_TXT;
    public UILabel stageDifficulty_TXT;
    public UILabel rewardGold_TXT;
    public UILabel spawnMob00_TXT;
    public UILabel spawnMob01_TXT;
    public UILabel spawnMob02_TXT;


    


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

   

   

    void Start()
    {
        //PlayerPrefs.DeleteAll();
       
    }

    private void Update()
    {
        LoadStageInfomation();


       
        worldName_TXT.text = worldName_Kr + " (" + stageIndex + ")";
        properLevel_TXT.text = "" + properLevel;
        stageDifficulty_TXT.text = "" + stageDifficulty;
        rewardGold_TXT.text = "" + rewardGold;
        spawnMob00_TXT.text = "" + spawnMob00;
        spawnMob01_TXT.text = "" + spawnMob01;
        spawnMob02_TXT.text = "" + spawnMob02;
       



        // properLevel_TXT.text = properLevel_TXT


        //std = _stageValue;
        //lsn = loadSceneNo;
        //Debug.Log("lsn : "+  lsn);
    }


    public void LoadStageInfomation()
    {
        //StartCoroutine(LoadStageInfomationWait());


        if (popWindow.activeInHierarchy == true)
        {
            LoadStageInfoData(std);
            std = _stageValue;
            _stageValue = PlayerPrefs.GetInt("StageValue", _stageValue);

            //Debug.Log("_stageValue저장성공 : " + _stageValue);
            //Debug.Log("바보다");
        }
        else
        {

        }
       // Debug.Log("스테이지인포로딩완료");

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
        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;
        loadSceneNo = WorldSelecterManager.Instance().loadSceneNo;

    }

    public void LoadIngameScene()
    {
        CharacterDatamanager.Instance().Key -= 1;
        PlayerPrefs.SetInt("Key", CharacterDatamanager.Instance().Key);
        if (CharacterDatamanager.Instance().Key < 30)
            Assets.SimpleAndroidNotifications.KeyPlusManager.Instance().KeyPlusTimeStart();
        SceneManager.LoadScene(loadSceneNo);
    }



    IEnumerator LoadStageInfomationWait()
    {

        //yield return new WaitForSeconds(0f);
       
       
        //_stageValue = PlayerPrefs.GetInt("StageValue", _stageValue);
        //LoadStageInfoData(std);
        //yield break;

        int i = 0;
        while (i < 1)
        {
            LoadStageInfoData(std);
            _stageValue = PlayerPrefs.GetInt("StageValue", _stageValue);
          

            yield return new WaitForSeconds(0f);

            Debug.Log("_stageValue저장성공 : " + _stageValue);
            Debug.Log("std : " + std);

            i++;
        }

        //if (popWindow.activeInHierarchy == true)
        //{
        //    std = _stageValue;
        //    _stageValue = PlayerPrefs.GetInt("StageValue", _stageValue);
        //    //Debug.Log("_stageValue저장성공 : " + _stageValue);
        //    //Debug.Log("바보다");

        //}
        //else
        //{

        //}
        //Debug.Log("스테이지인포로딩완료");

       

    }
}
