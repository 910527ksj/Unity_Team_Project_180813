using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class SkillDataManager : MonoBehaviour
{
    public TextAsset jsonData;
    public int index;
    public string skill_Name_Kr;
    public string skill_Name;
    public float coolDown;
    public float skill_PlayTime;
    public float min_Lv;
    public float max_Lv;
    public float skill_atk_Dmg;
  

    static SkillDataManager _instance = null;

    public static SkillDataManager Instance()
    {

        return _instance;

    }

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
        //LoadCharaterData00();
    }

    public void LoadSkillData00(int chrskill)
    {
        var DATASKILL = JSON.Parse(jsonData.text);
        index = (int)DATASKILL[chrskill]["Index"];
        skill_Name_Kr = (string)DATASKILL[chrskill]["Skill_Name_Kr"];
        skill_Name = (string)DATASKILL[chrskill]["Skill_Name"];
        coolDown = (float)DATASKILL[chrskill]["CoolDown"];
        skill_PlayTime = (float)DATASKILL[chrskill]["Skill_PlayTime"];
        min_Lv = (float)DATASKILL[chrskill]["Min_Lv"];
        max_Lv = (float)DATASKILL[chrskill]["Max_Lv"];
        skill_atk_Dmg = (float)DATASKILL[chrskill]["Atk_Dmg"];
       
    }

}
