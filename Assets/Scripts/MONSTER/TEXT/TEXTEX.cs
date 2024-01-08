using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEXTEX: MonoBehaviour
{
    public float atP;
    public string atS;
    public GameObject Pui;
    public HUDText hudText;
    public GameObject PTEXT;
    public GameObject uiP;
    public GameObject point;
    public float HP;

    private void Start()
    {
        HP = gameObject.GetComponent<MONSTERAI02>().monster_HP;
        uiP = GameObject.Find("UI_Ingame");
        if (Pui == null)
        {           
            GameObject spawn = Instantiate(PTEXT) as GameObject;
            spawn.transform.parent = uiP.transform;
            spawn.GetComponent<UIFollowTarget>().target = point.transform;
            spawn.transform.localScale=new Vector3 (2, 2, 2);
            spawn.GetComponentInChildren<MONSTERHP>().myObj = gameObject;
            spawn.GetComponentInChildren<MONSTERHP>().hpFull = gameObject.GetComponent<MONSTERAI02>().monster_HP;
            Pui = spawn;
        }
    }

    public void Textadd()
    {
        if (Pui != null)
        {

            hudText = Pui.GetComponent<HUDText>();
            hudText.Add(atS, Color.red, 0f);
        }
    } 
}
