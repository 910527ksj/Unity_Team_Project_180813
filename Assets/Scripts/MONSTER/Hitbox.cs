using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Hitbox : MonoBehaviour
{
    public GameObject hitEffect;
    public TextAsset jsonM;//몬스터 데이터 받는곳?
    public bool ating;//공격중이니?
    public float intime;//히트박스 생성 시간은?    
    public float backpow;//넉백돼냐?넉백값은?
    public float atp;//데미지 적용해서 플레이어한테 주는값은?
    public float boxs;//히트박스 크기조절할꺼니?
    public GameObject hitdtaget;//맞는 대상이야?
    public GameObject myobj;//누구 데미지임?
    public GameObject intext;  

    void Awake()
    {
        // var C = JSON.Parse(jsonM.text);       
    }

    private void Start()
    {                      
        //hitdtaget = GameObject.Find("Player");
        hitdtaget = GameObject.FindGameObjectWithTag("Player");
        //boxs 박스 크기값조정       
    }

    void Update()
    {
        if (GetComponentInParent<MONSTERAI02>() != null)
        {
            myobj = GetComponentInParent<MONSTERAI02>().my;
            GetComponentInParent<MONSTERAI02>().monsterATing = ating;
        }       
    }    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ating = true;           
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ating = false;           
        }
    }
    public void Ef()
    {
        Instantiate(hitEffect, hitdtaget.transform);
    }
}
/*public class Playerhitbox : MonoBehaviour
{//플레이어 공격범위
    static Playerhitbox _instance = null;
    public static Playerhitbox Instance()
    {
        return _instance;
    }//인스턴스화
    public GameObject hitEffect;
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
        SkillDataManager.Instance().LoadSkillData00(0);
        index = SkillDataManager.Instance().index;
        skill_Name_Kr = SkillDataManager.Instance().skill_Name_Kr;
        skill_Name = SkillDataManager.Instance().skill_Name;
        coolDown = SkillDataManager.Instance().coolDown;
        skill_PlayTime = SkillDataManager.Instance().skill_PlayTime;
        min_Lv = SkillDataManager.Instance().min_Lv;
        max_Lv = SkillDataManager.Instance().max_Lv;
        skill_atk_Dmg = SkillDataManager.Instance().skill_atk_Dmg;
        skill_atk_Dmg_Upgrade_Value = SkillDataManager.Instance().skill_atk_Dmg_Upgrade_Value;
        upgrade_Required_Coin = SkillDataManager.Instance().upgrade_Required_Coin;
        Debug.Log("skill_Name_Kr :" + skill_Name_Kr);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
        }
    }
    public void DamageSkill01()
    {
        skill_atk_Dmg--;
    }
}*/