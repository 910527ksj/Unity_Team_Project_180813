using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class MonsterEX : MonoBehaviour
{
    static MonsterEX _instance = null;

    public static MonsterEX Instance()
    {

        return _instance;

    }
    public TextAsset jsonData;
    public TextAsset jsonData02;
    public int mob_LV;
    public float mob_EXP;
    public float monster_Index;
    public string monster_Name;
    public float monster_Type;
    public float attack_Range;
    public float skill01_Damage;
    public float skill02_Damage;
    public float skill03_Damage;
    public float monster_MoveSpeed;
    public float rotation_Speed;
    public float attack_Speed;
    public float monsterLV;
    public float monster_HP;
    public float score;



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
        //LoadMonsData00();
    }
    
    public void LoadMonsData00(int monsno)
    {
        var DATAMONS = JSON.Parse(jsonData.text);
        monster_Index = (float)DATAMONS[monsno]["Monster_Index"];
        monster_Name= (string)DATAMONS[monsno]["Monster_Name"];
        monster_Type= (float)DATAMONS[monsno]["Monster_Type"];
        attack_Range = (float)DATAMONS[monsno]["Attack_Range"];
        skill01_Damage = (float)DATAMONS[monsno]["Skill01_Damage"] +(mob_LV * 2);
        skill02_Damage = (float)DATAMONS[monsno]["Skill02_Damage"] +(mob_LV * 2);
        skill03_Damage = (float)DATAMONS[monsno]["Skill03_Damage"] + (mob_LV * 2);
        monster_MoveSpeed= (float)DATAMONS[monsno]["Monster_MoveSpeed"];
        rotation_Speed= (float)DATAMONS[monsno]["Rotation_Speed"];
        attack_Speed = (float)DATAMONS[monsno]["Attack_Speed"];
        //monsterLV= (float)DATAMONS[monsno]["MonsterLV"];
        monster_HP= (float)DATAMONS[monsno]["Monster_HP"] + (mob_LV * 10);
    }


    public void LoadMonsEXPData00(int monsno)
    {
        var DATAMOBEXP = JSON.Parse(jsonData02.text);
        mob_LV = (int)DATAMOBEXP[monsno]["Mob_LV"];
        mob_EXP = (float)DATAMOBEXP[monsno]["Mob_EXP"];
       
    }


}
