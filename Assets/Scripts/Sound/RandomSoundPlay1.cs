using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlay1 : MonoBehaviour
{

    public AudioClip[] waterDrop;

    public float playertime;

    private void Start()
    {
        
    }

    private void Update()
    {


        playertime += Time.deltaTime;

        if(playertime >= 0.35f)
        {
            playertime = 0;
            StartCoroutine(WaterDropWait());
        }


    }




    IEnumerator WaterDropWait()
    {

        float time =  Random.Range(0.5f, 1f);

        yield return new WaitForSeconds(time);

        SoundManager.Instance.RandomSoundEffect(waterDrop);

    }


}
