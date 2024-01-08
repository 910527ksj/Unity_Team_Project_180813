using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageSlotScript : MonoBehaviour
{
    static StageSlotScript _instance = null;

    public static StageSlotScript Instance()
    {
        return _instance;
    }

   public int _stageValue;
  

    //public int index;
    //public int worldIndex;
    //public int stageIndex;
    //public string worldName_Kr;
    //public string worldName;
    //public int properLevel;
    //public int stageDifficulty;
    //public int rewardGold;
    //public int spawnMob00;
    //public int spawnMob01;
    //public int spawnMob02;
    //public int spawnMob03;
    //public int spawnMob04;
    //public int spawnMob05;
    //public int spawnMob06;
    //public int spawnMob07;
    //public int spawnMob08;
    //public int spawnMob09;

    public int stageValue 
    {
        get
        {
            return _stageValue;
        }
        set
        {
            _stageValue = value;
        }
    }






    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //LoadWorld01Data();
    }

    void Update()
    {
        
    }

    public void Stage01Btn()
    {
     
        _stageValue = 0;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();

    }

    public void Stage02Btn()
    {
       
        _stageValue = 1;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage03Btn()
    {
       
        _stageValue = 2;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();


    }

    public void Stage04Btn()
    {
        _stageValue = 3;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage05Btn()
    {
        
        _stageValue = 4;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage06Btn()
    {
        _stageValue =5;
        SaveStageValue();
       // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage07Btn()
    {
        
        _stageValue = 6;
        SaveStageValue();
       // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage08Btn()
    {
        _stageValue = 7;
        SaveStageValue();
       // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage09Btn()
    {
        _stageValue = 8;
        SaveStageValue();

       // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage10Btn()
    {
        
        _stageValue = 9;
        SaveStageValue();
       // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage11Btn()
    {

        _stageValue = 10;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();

    }

    public void Stage12Btn()
    {

        _stageValue = 11;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage13Btn()
    {

        _stageValue = 12;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();


    }

    public void Stage14Btn()
    {
        _stageValue = 13;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage15Btn()
    {

        _stageValue = 14;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage16Btn()
    {
        _stageValue = 15;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage17Btn()
    {

        _stageValue = 16;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage18Btn()
    {
        _stageValue = 17;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage19Btn()
    {
        _stageValue = 18;
        SaveStageValue();

        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage20Btn()
    {

        _stageValue = 19;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage21Btn()
    {

        _stageValue = 20;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();

    }

    public void Stage22Btn()
    {

        _stageValue = 21;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage23Btn()
    {

        _stageValue = 22;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();


    }

    public void Stage24Btn()
    {
        _stageValue = 23;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage25Btn()
    {

        _stageValue = 24;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage26Btn()
    {
        _stageValue = 25;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage27Btn()
    {

        _stageValue = 26;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage28Btn()
    {
        _stageValue = 27;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage29Btn()
    {
        _stageValue = 28;
        SaveStageValue();

        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage30Btn()
    {

        _stageValue = 29;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage31Btn()
    {

        _stageValue = 30;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();

    }

    public void Stage32Btn()
    {

        _stageValue = 31;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage33Btn()
    {

        _stageValue = 32;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();


    }

    public void Stage34Btn()
    {
        _stageValue = 33;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage35Btn()
    {

        _stageValue = 34;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage36Btn()
    {
        _stageValue = 35;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage37Btn()
    {

        _stageValue = 36;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage38Btn()
    {
        _stageValue = 37;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage39Btn()
    {
        _stageValue = 38;
        SaveStageValue();

        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage40Btn()
    {

        _stageValue = 39;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage41Btn()
    {

        _stageValue = 40;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();

    }

    public void Stage42Btn()
    {

        _stageValue = 41;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage43Btn()
    {

        _stageValue = 42;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();


    }

    public void Stage44Btn()
    {
        _stageValue = 43;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage45Btn()
    {

        _stageValue = 44;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage46Btn()
    {
        _stageValue = 45;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage47Btn()
    {

        _stageValue = 46;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage48Btn()
    {
        _stageValue = 47;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage49Btn()
    {
        _stageValue = 48;
        SaveStageValue();

        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage50Btn()
    {

        _stageValue = 49;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage51Btn()
    {

        _stageValue = 50;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();

    }

    public void Stage52Btn()
    {

        _stageValue = 51;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage53Btn()
    {

        _stageValue = 52;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();


    }

    public void Stage54Btn()
    {
        _stageValue = 53;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage55Btn()
    {

        _stageValue = 54;
        SaveStageValue();
        //StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage56Btn()
    {
        _stageValue = 55;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage57Btn()
    {

        _stageValue = 56;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage58Btn()
    {
        _stageValue = 57;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage59Btn()
    {
        _stageValue = 58;
        SaveStageValue();

        // StageInfoScript.Instance().LoadStageInfomation();
    }

    public void Stage60Btn()
    {

        _stageValue = 59;
        SaveStageValue();
        // StageInfoScript.Instance().LoadStageInfomation();
    }





    public void SaveStageValue()
    {
        PlayerPrefs.SetInt("StageValue", _stageValue);
        //Debug.Log("_stageValue저장성공 : " + _stageValue);
    }

    public void LoadStageValue()
    {
        _stageValue = PlayerPrefs.GetInt("StageValue", _stageValue);
        //Debug.Log("_stageValue저장성공 : " + _stageValue);
    }


   




    //public void LoadWorld01Data()
    //{
    //    if (gameObject.name == "Stage01")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(0);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;

    //    }

    //    if (gameObject.name == "Stage02")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(1);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;


    //    }

    //    if (gameObject.name == "Stage03")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(2);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;
    //    }

    //    if (gameObject.name == "Stage04")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(3);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;

    //    }

    //    if (gameObject.name == "Stage05")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(4);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;
    //    }

    //    if (gameObject.name == "Stage06")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(5);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;
    //    }

    //    if (gameObject.name == "Stage07")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(6);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;
    //    }

    //    if (gameObject.name == "Stage08")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(7);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;

    //    }

    //    if (gameObject.name == "Stage09")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(8);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;
    //    }

    //    if (gameObject.name == "Stage10")
    //    {
    //        WorldSelecterManager.Instance().LoadWorldData(9);

    //        index = WorldSelecterManager.Instance().index;
    //        worldIndex = WorldSelecterManager.Instance().worldIndex;
    //        stageIndex = WorldSelecterManager.Instance().stageIndex;
    //        worldName_Kr = WorldSelecterManager.Instance().worldName_Kr;
    //        worldName = WorldSelecterManager.Instance().worldName;
    //        properLevel = WorldSelecterManager.Instance().properLevel;
    //        stageDifficulty = WorldSelecterManager.Instance().stageDifficulty;
    //        rewardGold = WorldSelecterManager.Instance().rewardGold;
    //        spawnMob00 = WorldSelecterManager.Instance().spawnMob00;
    //        spawnMob01 = WorldSelecterManager.Instance().spawnMob01;
    //        spawnMob02 = WorldSelecterManager.Instance().spawnMob02;
    //        spawnMob03 = WorldSelecterManager.Instance().spawnMob03;
    //        spawnMob04 = WorldSelecterManager.Instance().spawnMob04;
    //        spawnMob05 = WorldSelecterManager.Instance().spawnMob05;
    //        spawnMob06 = WorldSelecterManager.Instance().spawnMob06;
    //        spawnMob07 = WorldSelecterManager.Instance().spawnMob07;
    //        spawnMob08 = WorldSelecterManager.Instance().spawnMob08;
    //        spawnMob09 = WorldSelecterManager.Instance().spawnMob09;
    //    }



    //}
}
