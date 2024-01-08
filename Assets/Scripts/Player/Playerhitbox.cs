using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Playerhitbox : MonoBehaviour
{//플레이어 공격범위
    static Playerhitbox _instance = null;
    public static Playerhitbox Instance()
    {
        return _instance;
    }//인스턴스화
    public GameObject hitEffect;
    public GameObject how;
    public GameObject point;
    public bool ating;
    public float atk;
    /////////////////////////////////////////////캐릭터 스킬/////////////////////////////////////////////////
    void Start()
    {
        //   atk=GameManagerScript.Instance().atk;
        atk = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Monster")
        {
            how = other.gameObject;
            ating = true;                   
        }
    }
    private void OnTriggerExit(Collider other)    
    {

        if (other.gameObject.tag == "Monster")
        {
            how = null;
            ating = false;
        }
    }
    public void Hitmonster()
    {
        if (ating == true)
        {
            if (how != null)
            {
                if (how.GetComponent<MONSTERAI02>() != null)
                {                    
                    how.GetComponent<MONSTERAI02>().Hit();
                    ating = false;
                    gameObject.SetActive(false);
                }
            }           
        }
    }
    public void Ef()
    {
        Instantiate(hitEffect,transform);
    }
}

