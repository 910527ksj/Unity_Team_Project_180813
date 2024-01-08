
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageStateScript : MonoBehaviour
{
    static StageStateScript _instance = null;

    public static StageStateScript Instance()
    {
        return _instance;
    }

   

    public UIButton button;
    public GameObject StageClearBtn;
    public GameObject UserClearInfoManager;

    public UILabel StageNoTxt;

    public int _stageStateValue;
    

    public int index;
    public int worldIndex;
    public int stageIndex;





    //public int stageStateValue
    //{
    //    get
    //    {
    //        return _stageStateValue;
    //    }
    //    set
    //    {
    //        _stageStateValue = value;
    //    }
    //}

    private void Awake()
    {
        UserClearInfoManager = GameObject.Find("UserClearInfoManager");
    }



    void Start()
    {

       

        LoadWorldStageData();

       
        //StartCoroutine(WaitTime());


    }

    void Update()
    {

        StageNoTxt.text = "" + worldIndex +" - "  + stageIndex;

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //   // _stageStateValue = 0;
        //    SaveStateStageDefault();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    //_stageStateValue = 1;
        //    SaveStateStageClear();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    //_stageStateValue = 2;
        //    SaveStateStageDisable();
        //}


        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    SaveStageStateValue();
        //    //Debug.Log("9번버튼눌림");
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    LoadStageStateValue();
        //    //Debug.Log("0번버튼눌림");
        //}

        if (_stageStateValue == 0)//기본 상태
        {
            Buttonable();
            StageClearBtn.SetActive(false);
        }
        if (_stageStateValue == 1)//클리어상태
        {
            Buttonable();
            StageClearBtn.SetActive(true);
        }
        if (_stageStateValue == 2)//잠김상태
        {
            ButtonDisable();
            StageClearBtn.SetActive(false);
        }

        

    }

    

    public void SaveStateStageDefault()
    {
        //PlayerPrefs.SetInt("StageStateValue", +stageIndex+ _stageStateValue);
        _stageStateValue = 0;
        Buttonable();
        StageClearBtn.SetActive(false);
       
        
        //UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[0] = 0;
        //UserClearInfoManager.Instance().stageClearValue[0] = 0;
        //PlayerPrefs.SetInt("StageStateValue",  _stageStateValue);
        //Debug.Log("_stageValue저장성공 : " + _stageStateValue);
    }

    public void SaveStateStageClear( )
    {
        //PlayerPrefs.SetInt("StageStateValue", +stageIndex+ _stageStateValue);
        _stageStateValue = 1;
        Buttonable();
        StageClearBtn.SetActive(true);
        //UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[0] = 1;
        //UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[0 + 1] = 0;

        //UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[0] = 1;
        //UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[0 + 1] = 0;
        //UserClearInfoManager.Instance().stageClearValue[0] = 1;
        //UserClearInfoManager.Instance().stageClearValue[0 +1] = 0;
        //PlayerPrefs.SetInt("StageStateValue",  _stageStateValue);
        //Debug.Log("_stageValue저장성공 : " + _stageStateValue);
    }

    public void SaveStateStageDisable( )
    {
        //PlayerPrefs.SetInt("StageStateValue", +stageIndex+ _stageStateValue);
        _stageStateValue = 2;
        ButtonDisable();
        StageClearBtn.SetActive(false);
        //UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[0] = 2;
        //UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[0] = 2;
        //UserClearInfoManager.Instance().stageClearValue[0] = 2;
        //PlayerPrefs.SetInt("StageStateValue",  _stageStateValue);
        //Debug.Log("_stageValue저장성공 : " + _stageStateValue);
    }



    //public void LoadStageStateValue01()
    //{
    //    //_stageStateValue = PlayerPrefs.GetInt("StageStateValue", +stageIndex+ _stageStateValue);
    //    _stageStateValue = PlayerPrefs.GetInt("StageStateValue",  _stageStateValue);
    //    Debug.Log("_stageValue저장성공 : " + _stageStateValue);
    //}



    public void ButtonDisable()
    {
        button.SetState(UIButtonColor.State.Disabled, true);

        button.isEnabled = false;

    }

    public void Buttonable()
    {
        button.SetState(UIButtonColor.State.Normal, true);

        button.isEnabled = true;

    }

    public void LoadWorldStageData()
    {
        if (gameObject.name == "Stage01")
        {
            WorldSelecterManager.Instance().LoadWorldData(0);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;


           _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[0];
            //Debug.Log("Stage01 : " + _stageStateValue);

            //_stageStateValue = UserClearInfoManager.Instance().stageClearValue[0];



        }
        if (gameObject.name == "Stage02")
        {
            WorldSelecterManager.Instance().LoadWorldData(1);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[1];
           // Debug.Log("Stage01 : " + _stageStateValue);
           
        }
        if (gameObject.name == "Stage03")
        {
            WorldSelecterManager.Instance().LoadWorldData(2);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[2];
           // Debug.Log("Stage03 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage04")
        {
            WorldSelecterManager.Instance().LoadWorldData(3);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[3];
            //Debug.Log("Stage04 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage05")
        {
            WorldSelecterManager.Instance().LoadWorldData(4);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[4];
            //Debug.Log("Stage05 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage06")
        {
            WorldSelecterManager.Instance().LoadWorldData(5);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[5];
            //Debug.Log("Stage06 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage07")
        {
            WorldSelecterManager.Instance().LoadWorldData(6);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[6];
            //Debug.Log("Stage07 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage08")
        {
            WorldSelecterManager.Instance().LoadWorldData(7);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[7];
           /// Debug.Log("Stage08 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage09")
        {
            WorldSelecterManager.Instance().LoadWorldData(8);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[8];
           // Debug.Log("Stage09 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage10")
        {
            WorldSelecterManager.Instance().LoadWorldData(9);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[9];
            //Debug.Log("Stage10 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage11")
        {
            WorldSelecterManager.Instance().LoadWorldData(10);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;


            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[10];
            //Debug.Log("Stage01 : " + _stageStateValue);

            //_stageStateValue = UserClearInfoManager.Instance().stageClearValue[0];



        }
        if (gameObject.name == "Stage12")
        {
            WorldSelecterManager.Instance().LoadWorldData(11);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[11];
            // Debug.Log("Stage01 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage13")
        {
            WorldSelecterManager.Instance().LoadWorldData(12);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[12];
            // Debug.Log("Stage03 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage14")
        {
            WorldSelecterManager.Instance().LoadWorldData(13);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[13];
            //Debug.Log("Stage04 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage15")
        {
            WorldSelecterManager.Instance().LoadWorldData(14);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[14];
            //Debug.Log("Stage05 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage16")
        {
            WorldSelecterManager.Instance().LoadWorldData(15);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[15];
            //Debug.Log("Stage06 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage17")
        {
            WorldSelecterManager.Instance().LoadWorldData(16);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[16];
            //Debug.Log("Stage07 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage18")
        {
            WorldSelecterManager.Instance().LoadWorldData(17);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[17];
            /// Debug.Log("Stage08 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage19")
        {
            WorldSelecterManager.Instance().LoadWorldData(18);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[18];
            // Debug.Log("Stage09 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage20")
        {
            WorldSelecterManager.Instance().LoadWorldData(19);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[19];
            //Debug.Log("Stage10 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage21")
        {
            WorldSelecterManager.Instance().LoadWorldData(20);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;


            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[20];
            //Debug.Log("Stage01 : " + _stageStateValue);

            //_stageStateValue = UserClearInfoManager.Instance().stageClearValue[0];



        }
        if (gameObject.name == "Stage22")
        {
            WorldSelecterManager.Instance().LoadWorldData(21);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[21];
            // Debug.Log("Stage01 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage23")
        {
            WorldSelecterManager.Instance().LoadWorldData(22);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[22];
            // Debug.Log("Stage03 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage24")
        {
            WorldSelecterManager.Instance().LoadWorldData(23);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[23];
            //Debug.Log("Stage04 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage25")
        {
            WorldSelecterManager.Instance().LoadWorldData(24);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[24];
            //Debug.Log("Stage05 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage26")
        {
            WorldSelecterManager.Instance().LoadWorldData(25);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[25];
            //Debug.Log("Stage06 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage27")
        {
            WorldSelecterManager.Instance().LoadWorldData(26);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[26];
            //Debug.Log("Stage07 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage28")
        {
            WorldSelecterManager.Instance().LoadWorldData(27);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[27];
            /// Debug.Log("Stage08 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage29")
        {
            WorldSelecterManager.Instance().LoadWorldData(28);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[28];
            // Debug.Log("Stage09 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage30")
        {
            WorldSelecterManager.Instance().LoadWorldData(29);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[29];
            //Debug.Log("Stage10 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage31")
        {
            WorldSelecterManager.Instance().LoadWorldData(30);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;


            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[30];
            //Debug.Log("Stage01 : " + _stageStateValue);

            //_stageStateValue = UserClearInfoManager.Instance().stageClearValue[0];



        }
        if (gameObject.name == "Stage32")
        {
            WorldSelecterManager.Instance().LoadWorldData(31);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[31];
            // Debug.Log("Stage01 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage33")
        {
            WorldSelecterManager.Instance().LoadWorldData(32);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[32];
            // Debug.Log("Stage03 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage34")
        {
            WorldSelecterManager.Instance().LoadWorldData(33);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[33];
            //Debug.Log("Stage04 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage35")
        {
            WorldSelecterManager.Instance().LoadWorldData(34);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[34];
            //Debug.Log("Stage05 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage36")
        {
            WorldSelecterManager.Instance().LoadWorldData(35);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[35];
            //Debug.Log("Stage06 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage37")
        {
            WorldSelecterManager.Instance().LoadWorldData(36);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[36];
            //Debug.Log("Stage07 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage38")
        {
            WorldSelecterManager.Instance().LoadWorldData(37);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[37];
            /// Debug.Log("Stage08 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage39")
        {
            WorldSelecterManager.Instance().LoadWorldData(38);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[38];
            // Debug.Log("Stage09 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage40")
        {
            WorldSelecterManager.Instance().LoadWorldData(39);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[39];
            //Debug.Log("Stage10 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage41")
        {
            WorldSelecterManager.Instance().LoadWorldData(40);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;


            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[40];
            //Debug.Log("Stage01 : " + _stageStateValue);

            //_stageStateValue = UserClearInfoManager.Instance().stageClearValue[0];



        }
        if (gameObject.name == "Stage42")
        {
            WorldSelecterManager.Instance().LoadWorldData(41);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[41];
            // Debug.Log("Stage01 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage43")
        {
            WorldSelecterManager.Instance().LoadWorldData(42);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[42];
            // Debug.Log("Stage03 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage44")
        {
            WorldSelecterManager.Instance().LoadWorldData(43);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[43];
            //Debug.Log("Stage04 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage45")
        {
            WorldSelecterManager.Instance().LoadWorldData(44);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[44];
            //Debug.Log("Stage05 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage46")
        {
            WorldSelecterManager.Instance().LoadWorldData(45);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[45];
            //Debug.Log("Stage06 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage47")
        {
            WorldSelecterManager.Instance().LoadWorldData(46);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[46];
            //Debug.Log("Stage07 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage48")
        {
            WorldSelecterManager.Instance().LoadWorldData(47);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[47];
            /// Debug.Log("Stage08 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage49")
        {
            WorldSelecterManager.Instance().LoadWorldData(48);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[48];
            // Debug.Log("Stage09 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage50")
        {
            WorldSelecterManager.Instance().LoadWorldData(49);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[49];
            //Debug.Log("Stage10 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage51")
        {
            WorldSelecterManager.Instance().LoadWorldData(50);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;


            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[50];
            //Debug.Log("Stage01 : " + _stageStateValue);

            //_stageStateValue = UserClearInfoManager.Instance().stageClearValue[0];



        }
        if (gameObject.name == "Stage52")
        {
            WorldSelecterManager.Instance().LoadWorldData(51);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[51];
            // Debug.Log("Stage01 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage53")
        {
            WorldSelecterManager.Instance().LoadWorldData(52);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[52];
            // Debug.Log("Stage03 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage54")
        {
            WorldSelecterManager.Instance().LoadWorldData(53);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[53];
            //Debug.Log("Stage04 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage55")
        {
            WorldSelecterManager.Instance().LoadWorldData(54);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[54];
            //Debug.Log("Stage05 : " + _stageStateValue);
        }

        if (gameObject.name == "Stage56")
        {
            WorldSelecterManager.Instance().LoadWorldData(55);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[55];
            //Debug.Log("Stage06 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage57")
        {
            WorldSelecterManager.Instance().LoadWorldData(56);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[56];
            //Debug.Log("Stage07 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage58")
        {
            WorldSelecterManager.Instance().LoadWorldData(57);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[57];
            /// Debug.Log("Stage08 : " + _stageStateValue);

        }
        if (gameObject.name == "Stage59")
        {
            WorldSelecterManager.Instance().LoadWorldData(58);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[58];
            // Debug.Log("Stage09 : " + _stageStateValue);
        }
        if (gameObject.name == "Stage60")
        {
            WorldSelecterManager.Instance().LoadWorldData(59);

            index = WorldSelecterManager.Instance().index;
            worldIndex = WorldSelecterManager.Instance().worldIndex;
            stageIndex = WorldSelecterManager.Instance().stageIndex;
            _stageStateValue = UserClearInfoManager.GetComponent<UserClearInfoManager>().stageClearValue[59];
            //Debug.Log("Stage10 : " + _stageStateValue);
        }
    }

    
}
