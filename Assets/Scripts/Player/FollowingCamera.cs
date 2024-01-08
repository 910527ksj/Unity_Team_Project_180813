using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{

    public Transform player;
   
    private Vector3 offset;

   


    private void Start()
    {

        StartCoroutine(WaitSpawnTime());              
        if (player != null)
        {
            Debug.Log("성공적으로" + player.name + "카메라가 플레이어를 찾았습니다");
        }
        else
        {
            Debug.LogError(" 해당 카메라가 캐릭터를 찾는데 실패했습니다.");
            StartCoroutine(WaitSpawnTime());
        }


        
    }
    



    void Update()
    {
        
        transform.position = player.transform.position + offset;
        offset = transform.position - player.transform.position;
        transform.Translate(0, 1, -6);

    }


    IEnumerator WaitSpawnTime()
    {
        int i = 0;
        while (i < 1)
        {
           
            yield return new WaitForSeconds(0f);
            player = GameObject.Find("PlayerTransform").GetComponent<Transform>();

            

            Debug.Log("카메라 플레이어 찾기");

            i++;
        }
    }
}




   
