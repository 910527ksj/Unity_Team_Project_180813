using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlay : MonoBehaviour
{

    public AudioClip[] hitSound;



    private void Start()
    {
        SoundManager.Instance.RandomSoundEffect(hitSound);
    }

}
