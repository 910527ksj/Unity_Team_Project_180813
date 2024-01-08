using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill02_RageDash : MonoBehaviour
{
    static Skill02_RageDash _instance = null;
    public static Skill02_RageDash Instance()
    {
        return _instance;
    }//인스턴스화


    public GameObject hitEffect;
    //public GameObject skill02Effect;
    //public float effectStartTime;






    public int index;
    public string skill_Name_Kr;
    public string skill_Name;
    public float coolDown;
    public float skill_PlayTime;
    public string type;
    public float min_Lv;
    public float max_Lv;
    public float skill_atk_Dmg;
    public float skill_atk_Dmg_Upgrade_Value;
    public float upgrade_Required_Coin;







    /////////////////////////////////////////////캐릭터 스킬/////////////////////////////////////////////////



    void Start()
    {

       

        SkillDataManager.Instance().LoadSkillData00(1);



        index = SkillDataManager.Instance().index;
        skill_Name_Kr = SkillDataManager.Instance().skill_Name_Kr;
        skill_Name = SkillDataManager.Instance().skill_Name;
        coolDown = SkillDataManager.Instance().coolDown;
        skill_PlayTime = SkillDataManager.Instance().skill_PlayTime;
        min_Lv = SkillDataManager.Instance().min_Lv;
        max_Lv = SkillDataManager.Instance().max_Lv;
        skill_atk_Dmg = SkillDataManager.Instance().skill_atk_Dmg;
      

        Debug.Log("skill_Name_Kr :" + skill_Name_Kr);


        


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Instantiate(hitEffect, transform.position, transform.rotation);

           
            
        }
    }


    public void DamageSkill02()
    {
        skill_atk_Dmg--;
    }

          


    

}
