using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEXTPLAYER : MonoBehaviour
{
    public float atP;
    public string atS;
    public GameObject Pui;
    public HUDText hudText;
    public GameObject PTEXT;
    public GameObject uiP;
    public GameObject point;
    
    private void Start()
    {
        uiP = GameObject.Find("UI_Ingame");
        if (Pui == null)
        {
            GameObject spawn = Instantiate(PTEXT) as GameObject;
            spawn.transform.parent = uiP.transform;
            spawn.GetComponent<UIFollowTarget>().target = point.transform;
            spawn.transform.localScale = new Vector3(2, 2, 2);
            Pui = spawn;
        }
    }

    public void Textadd()
    {
        if (Pui != null)
        {
            atS = GetComponent<PlayerController>().monsterat.ToString("N0");            
            hudText = Pui.GetComponent<HUDText>();
            hudText.Add(atS, Color.white, 0f);
        }
    }
}