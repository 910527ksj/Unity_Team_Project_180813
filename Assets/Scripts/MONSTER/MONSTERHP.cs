using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONSTERHP : MonoBehaviour
{
    public GameObject myObj;
    public float hpFull;
    public float thisMonsterHp;
    public GameObject hpBar;

    void Update()
    {
        thisMonsterHp = myObj.GetComponent<MONSTERAI02>().monster_HP;
        if (hpFull <= thisMonsterHp)
        {
            hpBar.GetComponent<UIProgressBar>().value = 1;
        }
        if (hpFull > thisMonsterHp)
        {
            float hp;
            hp = thisMonsterHp / hpFull;
            hpBar.GetComponent<UIProgressBar>().value = hp;
        }               
    }
}
