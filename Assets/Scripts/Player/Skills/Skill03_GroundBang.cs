using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill03_GroundBang : MonoBehaviour
{
    static Skill03_GroundBang _instance = null;
    public static Skill03_GroundBang Instance()
    {
        return _instance;
    }//인스턴스화


    public GameObject hitEffect;
    public GameObject dustEffect;
    public GameObject GroundHitEffect;


   
    //public GameObject skillObj;
    






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

        if (other.gameObject.tag == "Ground")
        {
           // Debug.Log("바닥이랑 충돌체크함");
            Instantiate(GroundHitEffect, transform.position, transform.rotation);
            Instantiate(dustEffect, transform.position, transform.rotation);

        }
    }





    public void DamageSkill03()
    {
        skill_atk_Dmg--;
    }

          


    

}
