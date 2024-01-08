using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONbut : MonoBehaviour
{
    public GameObject playertaget;
    bool mbPress;
    public int i1;
    // Start is called before the first frame update
    void Start()
    {
        playertaget = GameObject.FindGameObjectWithTag("Player");
        UIEventListener.Get(gameObject).onPress += OnMoving;
    }
    void OnMoving(GameObject go, bool press)
    {
        mbPress = press;

    }    
    // Update is called once per frame
    void Update()
    {
        if (mbPress== true&&i1==0)
        {
           
            Debug.Log("누름중");
            playertaget.GetComponent<PlayerController>().auto = true;
            playertaget.GetComponent<PlayerController>().Atbut();
            StartCoroutine(Del());
            i1 = 1;
        }       
    }
    IEnumerator Del()
    {
        int i = 0;
        while (i < 1)
        {
            yield return new WaitForSeconds(0.2f);
            i1 = 0;            
            i++;
        }     
    }

}
