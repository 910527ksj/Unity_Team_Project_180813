using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUse : MonoBehaviour
{

    public GameObject playercon;


    private void Awake()
    {
       

    }

    void Start()
    {

        GameObject playercon = null;

        if (playercon != null)
        {
            Debug.Log("성공적으로" + playercon.name + "포션매니저가 플레이어 찾았음");
        }
        else
        {
            StartCoroutine(WaitFindPlayer());
            Debug.LogError("포션매니저가 플레이어 찾는중.");
        }

       
    }

    
    void Update()
    {
        
    }

    public void PotionUseBtn()
    {
        if(CharacterDatamanager.Instance().HpPotion >= 1)
        {
            playercon.GetComponentInChildren<PlayerController>().UserHPPotion();
        }
       
    }

    IEnumerator WaitFindPlayer()
    {
        int i = 0;
        while (i < 1)
        {

            yield return new WaitForSeconds(0f);
            playercon = GameObject.FindGameObjectWithTag("Player");



            //Debug.Log("포션 매니저가 플레이어 찾기");

            i++;
        }
    }

}
