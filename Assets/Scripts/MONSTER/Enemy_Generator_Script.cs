using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator_Script : MonoBehaviour
{
    public Transform regenPos;
    public GameObject enemyobj;
    public GameObject enenmyRespawnEffect;

    public float spawnTime;

    public int spawnCnt = 0;
    public int enemyCoolTime;
    public int maxSpawnCnt;

    float maxSpawnCntTime;
    float deltaSpawnTime = 0;

    public GameObject[] enemyPool;
    public int poolSize = 1;
    public int enemyObjCount;

    void Start()
    {
        enemyPool = new GameObject[poolSize];//10개짜리 배열을 만들겠다.  

        for (int i = 0; i < poolSize; ++i)
        {
            enemyPool[i] = Instantiate(enemyobj) as GameObject;

            enemyPool[i].SetActive(false);//게임오브젝트를 꺼둔다. 

        }

    }



    void Update()
    {
        if (spawnCnt >= maxSpawnCnt)
        {

            return;
        }

        maxSpawnCntTime += Time.deltaTime;

        deltaSpawnTime += Time.deltaTime;

        if (deltaSpawnTime > spawnTime & maxSpawnCntTime > enemyCoolTime)
        {
            deltaSpawnTime = 0;

            for (int i = 0; i < poolSize; i++)
            {
                if (enemyPool[i].activeSelf == true)//엑티브셀프 불값이 켜져있다면 다음 번호로 진행하라. 
                {
                    continue;
                }

                enemyPool[i].transform.position = regenPos.position;

                enemyPool[i].SetActive(true);

                //Instantiate(enenmyRespawnEffect, transform.position,transform.rotation);

                enemyPool[i].name = "Enemy_" + spawnCnt;

                ++spawnCnt;

                break;
            }
        }

        if (spawnCnt >= enemyObjCount)
        {
            maxSpawnCntTime = 0;
            spawnCnt = 0;
        }

    }


}

