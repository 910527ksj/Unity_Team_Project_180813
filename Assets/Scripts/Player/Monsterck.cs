using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterck : MonoBehaviour
{
    public GameObject myObj;
    public GameObject exitobj;
    // Start is called before the first frame update
    void Start()
    {
        myObj = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (exitobj != null)
        {
            if (exitobj.GetComponent<MONSTERAI02>().die == true)
            {
                myObj.GetComponent<PlayerController>().autotarget = null;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Monster")
        {
            MONSTERAI02 ack = other.GetComponent<MONSTERAI02>();
            if (ack == null)
            {

            }
            if (ack != null)
            {
                if (myObj.GetComponent<PlayerController>().autotarget == null)
                {
                    exitobj = other.gameObject;
                    myObj.GetComponent<PlayerController>().autotarget = other.gameObject;
                }
            }
        }                    
    }
    private void OnTriggerExit(Collider other)
    {
        if (exitobj == other)
        {
            myObj.GetComponent<PlayerController>().autotarget = null;
        }
    }
}
