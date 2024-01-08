using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONSTERck : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           // Debug.Log("플레이어를 발견햇습니다.");
            if (GetComponentInParent<MONSTERAI02>() != null)
            {
                GetComponentInParent<MONSTERAI02>().playerck = true;
            }
        }
    }//플레이어 발견
}


