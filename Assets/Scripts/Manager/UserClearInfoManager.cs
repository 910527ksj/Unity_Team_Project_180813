using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserClearInfoManager : MonoBehaviour
{
    static UserClearInfoManager _instance = null;

    public static UserClearInfoManager Instance()
    {
        return _instance;
    }



    //public List<bool> stageBool = new List<bool>();
    //public int StageClearBool01;
    //public int StageClearBool02;
    //public int StageClearBool03;
    //public int StageClearBool04;
    //public int StageClearBool05;

    public List<int> stageClearValue;

    //public List<int> stageClearValues = new List<int>();

    //public List<int> stageClearvalues
    //{
    //    get
    //    {
    //        return stageClearValue;
    //    }
    //    set
    //    {
    //        stageClearValue = value;
    //        if(stageClearValue.Count >=0)
    //        {
    //            SaveStageClearValue();
    //        }
    //    }
    //} 
    private void Awake()
    {
       



        LoadStageClearValue();




    }



    void Start()
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



        if (PlayerPrefs.GetInt("StageClearBoolValue", stageClearValue[0]) == 0)
        {
            InitialvalueLoad();
        }


        //if (PlayerPrefs.GetInt("StageClearBoolValue") == 0)
        //{
        //    InitialvalueLoad();
        //}

        //StageStateScript.Instance().LoadWorldStageData();


        //PlayerPrefs.DeleteAll();
        //LoadStageClearValue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            //StageClearBoolFalse();
            //SaveStageClearBoolValue();
            SaveStageClearValue();
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            //StageClearBoolTrue();
            //SaveStageClearBoolValue();
            LoadStageClearValue();
        }

        //Debug.Log("불값로그 저장 : " + stageBool[0]);
    }

    //public void StageClearBoolFalse()
    //{
    //    stageBool[0] = false;

    //}

    //public void StageClearBoolTrue()
    //{
    //    stageBool[0] = true;

    //}






    //public void SaveStageClearBoolValue()
    //{
    //    //List<bool> stageBool[0] = abcd;


    //    PlayerPrefs.SetString("StageClearBoolValue", stageBool[0].ToString());
    //    PlayerPrefs.SetString("StageClearBoolValue", stageBool[1].ToString());
    //    PlayerPrefs.SetString("StageClearBoolValue", stageBool[2].ToString());
    //    PlayerPrefs.SetString("StageClearBoolValue", stageBool[3].ToString());
    //    PlayerPrefs.SetString("StageClearBoolValue", stageBool[4].ToString());
    //    Debug.Log("불값01로그 저장 : " + stageBool[0]);
    //    Debug.Log("불값02로그 저장 : " + stageBool[1]);
    //    Debug.Log("불값03로그 저장 : " + stageBool[2]);
    //    Debug.Log("불값04로그 저장 : " + stageBool[3]);
    //    Debug.Log("불값05로그 저장 : " + stageBool[4]);

    //    //for (int i = 0; i <stageBool.Count ; i++)
    //    //{
    //    //    PlayerPrefs.SetString("StageClearBoolValue", stageBool[i].ToString());
    //    //}
    //}

    //public void LoadStageClearBoolValue()
    //{

    //    StageClearBool01 = PlayerPrefs.GetString("StageClearBoolValue", stageBool[0].ToString());
    //    StageClearBool02 = PlayerPrefs.GetString("StageClearBoolValue", stageBool[1].ToString());
    //    StageClearBool03 = PlayerPrefs.GetString("StageClearBoolValue", stageBool[2].ToString());
    //    StageClearBool04 = PlayerPrefs.GetString("StageClearBoolValue", stageBool[3].ToString());
    //    StageClearBool05 = PlayerPrefs.GetString("StageClearBoolValue", stageBool[4].ToString());
    //    Debug.Log("불값01로드 : " + stageBool[0]);
    //    Debug.Log("불값02로그로드 : " + stageBool[1]);
    //    Debug.Log("불값03로그로드 : " + stageBool[2]);
    //    Debug.Log("불값04로그로드 : " + stageBool[3]);
    //    Debug.Log("불값05로그로드 : " + stageBool[4]);

    //    //if (StageClearBool01.ToString() == "True")
    //    //{
    //    //    stageBool[0] = true;
    //    //}
    //    //if (StageClearBool01.ToString() == "False")
    //    //{
    //    //    stageBool[0] = false;
    //    //}

    //    //if (StageClearBool02.ToString() == "True")
    //    //{
    //    //    stageBool[1] = true;
    //    //}
    //    //if (StageClearBool02.ToString() == "False")
    //    //{
    //    //    stageBool[1] = false;
    //    //}
    //    //if (StageClearBool03.ToString() == "True")
    //    //{
    //    //    stageBool[2] = true;
    //    //}
    //    //if (StageClearBool03.ToString() == "False")
    //    //{
    //    //    stageBool[2] = false;
    //    //}
    //    //if (StageClearBool04.ToString() == "True")
    //    //{
    //    //    stageBool[3] = true;
    //    //}
    //    //if (StageClearBool04.ToString() == "False")
    //    //{
    //    //    stageBool[3] = false;
    //    //}
    //    //if (StageClearBool05.ToString() == "True")
    //    //{
    //    //    stageBool[4] = true;
    //    //}
    //    //if (StageClearBool04.ToString() == "False")
    //    //{
    //    //    stageBool[4] = false;
    //    //}

    //    //for (int i = 0; i < StageClearBool.Count; i++)
    //    //{
    //    //    StageClearBool[i] = PlayerPrefs.GetInt("StageClearBoolValue", StageClearBool[i]);
    //    //}

    //}


    public void SaveStageClearValue()
    {
        //PlayerPrefs.SetInt("StageClearBoolValue", stageClearValue[0] = 2);
        //PlayerPrefs.SetInt("StageClearBoolValue", stageClearValue[1] = 2);
        //PlayerPrefs.SetInt("StageClearBoolValue", stageClearValue[2] = 2);
        //PlayerPrefs.SetInt("StageClearBoolValue", stageClearValue[3] = 2);
        //PlayerPrefs.SetInt("StageClearBoolValue", stageClearValue[4] = 1);
        //Debug.Log("불값01로그 저장 : " + stageClearValue[0]);
        //Debug.Log("불값02로그 저장 : " + stageClearValue[1]);
        //Debug.Log("불값03로그 저장 : " + stageClearValue[2]);
        //Debug.Log("불값04로그 저장 : " + stageClearValue[3]);
        //Debug.Log("불값05로그 저장 : " + stageClearValue[4]);

        for (int i = 0; i < stageClearValue.Count; i++)
        {
            PlayerPrefs.SetInt("StageClearBoolValue"+i, stageClearValue[i]);
           // Debug.Log("StageClearBoolValue저장 : " + stageClearValue[i]); 
        }

    }

    public void LoadStageClearValue()
    {
        //stageClearValue[0] = PlayerPrefs.GetInt("StageClearBoolValue", stageClearValue[0]);
        //stageClearValue[1] = PlayerPrefs.GetInt("StageClearBoolValue", stageClearValue[1]);
        //stageClearValue[2] = PlayerPrefs.GetInt("StageClearBoolValue", stageClearValue[2]);
        //stageClearValue[3] = PlayerPrefs.GetInt("StageClearBoolValue", stageClearValue[3]);
        //stageClearValue[4] = PlayerPrefs.GetInt("StageClearBoolValue", stageClearValue[4]);
        //Debug.Log("불값01로그 로드 : " + stageClearValue[0]);
        //Debug.Log("불값02로그 로드 : " + stageClearValue[1]);
        //Debug.Log("불값03로그 로드 : " + stageClearValue[2]);
        //Debug.Log("불값04로그 로드 : " + stageClearValue[3]);
        //Debug.Log("불값05로그 로드 : " + stageClearValue[4]);

        for (int i = 0; i < stageClearValue.Count; i++)
        {
            stageClearValue[i] = PlayerPrefs.GetInt("StageClearBoolValue" +i, stageClearValue[i]);
            //Debug.Log("StageClearBoolValue로드 : " + stageClearValue[i]);
        }

    }




    public void InitialvalueLoad()
    {

        stageClearValue[0] = 0;
        stageClearValue[1] = 2;
        stageClearValue[2] = 2;
        stageClearValue[3] = 2;
        stageClearValue[4] = 2;
        stageClearValue[5] = 2;
        stageClearValue[6] = 2;
        stageClearValue[7] = 2;
        stageClearValue[8] = 2;
        stageClearValue[9] = 2;
        stageClearValue[10] = 2;
        stageClearValue[11] = 2;
        stageClearValue[12] = 2;
        stageClearValue[13] = 2;
        stageClearValue[14] = 2;
        stageClearValue[15] = 2;
        stageClearValue[16] = 2;
        stageClearValue[17] = 2;
        stageClearValue[18] = 2;
        stageClearValue[19] = 2;
        stageClearValue[20] = 2;
        stageClearValue[21] = 2;
        stageClearValue[22] = 2;
        stageClearValue[23] = 2;
        stageClearValue[24] = 2;
        stageClearValue[25] = 2;
        stageClearValue[26] = 2;
        stageClearValue[27] = 2;
        stageClearValue[28] = 2;
        stageClearValue[29] = 2;
        stageClearValue[30] = 2;
        stageClearValue[31] = 2;
        stageClearValue[32] = 2;
        stageClearValue[33] = 2;
        stageClearValue[34] = 2;
        stageClearValue[35] = 2;
        stageClearValue[36] = 2;
        stageClearValue[37] = 2;
        stageClearValue[38] = 2;
        stageClearValue[39] = 2;
        stageClearValue[40] = 2;
        stageClearValue[41] = 2;
        stageClearValue[42] = 2;
        stageClearValue[43] = 2;
        stageClearValue[44] = 2;
        stageClearValue[45] = 2;
        stageClearValue[46] = 2;
        stageClearValue[47] = 2;
        stageClearValue[48] = 2;
        stageClearValue[49] = 2;
        stageClearValue[50] = 2;
        stageClearValue[51] = 2;
        stageClearValue[52] = 2;
        stageClearValue[53] = 2;
        stageClearValue[54] = 2;
        stageClearValue[55] = 2;
        stageClearValue[56] = 2;
        stageClearValue[57] = 2;
        stageClearValue[58] = 2;
        stageClearValue[59] = 2;
    }
}
