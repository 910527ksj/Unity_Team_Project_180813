using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SimpleJSON;


public class MISAIL : MonoBehaviour
{//투사체
    public GameObject hitEffect;
    public GameObject target;
    public GameObject how;
    public float rs;//회전값
    public float i1;//리미트값
    public float pows;//스피드값
    public bool nontarget;
    public int lmt;
    public Rigidbody rb;
    public float ded;
    int b = 0;

    void Start()
    {
        //target=GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, ded);
        rb = GetComponent<Rigidbody>();
        how = GetComponentInParent<MONSTERAI02>().my;
    }
  
    void Update()
    {
      
        if (nontarget == false)
        {
            Moveobj();
            Vector3 dir = target.transform.position - transform.position;
            dir.y = 0f;
            dir.Normalize();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rs * Time.deltaTime);
            transform.Rotate(-90, 0, 0);
        }
        else
        {           
            Vector3 dir = target.transform.position - transform.position;
            dir.y = 0f;
            dir.Normalize();
            transform.Rotate(-90, 0, 0);
            Vector3 a = how.transform.forward * pows;
            rb.velocity = a;
        }
        
    }            

    public void Moveobj()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hit");
            Ef();            
            if (b == 0)
            {
                b = 1;
                target.GetComponent<PlayerController>().monsterat = how.GetComponent<MONSTERAI02>().skill01_Damage;
                target.GetComponent<PlayerController>().Hiting();               
            }
            Destroy(gameObject,0.2f);
        }
    }
    IEnumerator Wait02()
    {
        int i = 0;
        while (i < 1)
        {
            yield return new WaitForSeconds(0.8f);
            lmt = 1;
            i++;
        }
    }
    public void Ef()
    {
        Instantiate(hitEffect, target.transform);
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
