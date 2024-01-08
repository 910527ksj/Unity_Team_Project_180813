using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PlayerSkillDamage : MonoBehaviour
{
    public GameObject playertaget;
    public GameObject chDate;
    public GameObject myObj;
    public GameObject itemat;
    public Rigidbody rb;
    public float skipow01;
    public float skipow02;
    public float skipow03;
    public float atpow;
    public float skill01at;
    public float skill02at;
    public float skill03at;
    public float player01at;
    public float player02at;
    public float player03at;
    public float pulsAt;
    public float Rat;
    public float atP;
   
    void Start()
    {
        //itemat = GameObject.Find("CharacterDatamanager");
        rb = myObj.GetComponent<Rigidbody>();
        playertaget = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (myObj.GetComponent<MONSTERAI02>().die == false)
        {
            if (other.gameObject.tag == "Skill01")
            {
                Skill01pow();
                Debug.Log("적이랑 충돌");
            }
            if (other.gameObject.tag == "Skill02")
            {
                Skill02pow();
                Debug.Log("적이랑 충돌");
            }
            if (other.gameObject.tag == "Skill03")
            {
                Skill03pow();
                Debug.Log("적이랑 충돌");
            }
            if (other.gameObject.tag == "AT01")
            {
                GetComponentInParent<MONSTERAI02>().hitpow = atpow;
                Atpow();
                Debug.Log("적이랑 충돌");
            }
            if (other.gameObject.tag == "AT02")
            {
                GetComponentInParent<MONSTERAI02>().hitpow = atpow;
                Atpow();
                Debug.Log("적이랑 충돌");
            }
            if (other.gameObject.tag == "AT03")
            {
                GetComponentInParent<MONSTERAI02>().hitpow = atpow;
                Atpow();
                Debug.Log("적이랑 충돌");
            }
        }
    }
    public void Atpow()
    {
        GetComponentInParent<MONSTERAI02>().hitpow = atpow;
        player01at = playertaget.GetComponent<PlayerController>().at;
        //atpow += itemat.GetComponent<InventoryManagerScript>().total_AT_value;//아이템 데미지
        float Rat=Random.Range(0.7f, 1.2f);
        atP = Rat * player01at;
        GetComponentInParent<MONSTERAI02>().nowDamge = atP;       
        GetComponentInParent<MONSTERAI02>().Hit();
    }
    public void Skill01pow()
    {
        skill01at= playertaget.GetComponentInChildren<Skill01_Smash>().skill_atk_Dmg;
        //atpow += itemat.GetComponent<InventoryManagerScript>().total_AT_value;//아이템 데미지
        float Rat = Random.Range(0.7f, 1f);
        atP = Rat * skill01at;
        GetComponentInParent<MONSTERAI02>().nowDamge = atP;
        GetComponentInParent<MONSTERAI02>().hitpow = skipow01;
        GetComponentInParent<MONSTERAI02>().Hit();
    }
    public void Skill02pow()
    {
        skill02at= playertaget.GetComponentInChildren<Skill02_RageDash>().skill_atk_Dmg;
        //atpow += itemat.GetComponent<InventoryManagerScript>().total_AT_value;//아이템 데미지
        float Rat = Random.Range(0.7f, 1f);
        atP = Rat * skill02at;
        GetComponentInParent<MONSTERAI02>().nowDamge = atP;
        GetComponentInParent<MONSTERAI02>().hitpow = skipow02;
        GetComponentInParent<MONSTERAI02>().Hit();
    }
    public void Skill03pow()
    {
        skill03at = playertaget.GetComponentInChildren<Skill03_GroundBang>().skill_atk_Dmg;
        //atpow += itemat.GetComponent<InventoryManagerScript>().total_AT_value;//아이템 데미지
        float Rat = Random.Range(0.7f, 1f);
        atP = Rat * skill03at;
        GetComponentInParent<MONSTERAI02>().nowDamge = atP;
        GetComponentInParent<MONSTERAI02>().hitpow = skipow03;
        GetComponentInParent<MONSTERAI02>().Hit();
    }
}

