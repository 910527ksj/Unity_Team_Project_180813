using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioManager : MonoBehaviour
{

    static AudioManager _instance = null;


    public static AudioManager Instance()
    {
        return _instance;
    }

    public AudioClip music = null;
    public AudioClip music01 = null;

    //public AudioClip[] ad;

    //public int minValue;
    //public int maxValue;


    void Start()
    {

        if (_instance == null)
            _instance = this;

        if (music != null)
        {
            GetComponent<AudioSource>().clip = music;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }

        DontDestroyOnLoad(this.gameObject);

    }



    public void PlaySfx(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);

    }



    //IEnumerator PlaySfxRandom()
    //{
    //    AudioSource audio = GetComponent<AudioSource>();

    //    audio.clip = ad[Random.Range(minValue, maxValue)];
    //    audio.Play();

    //    //Destroy(soundObj, sfx.length);

    //    yield return new WaitForSeconds(3f);


    //}

}