using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    static PauseScript _instance = null;


    public static PauseScript Instance()

    {

        return _instance;

    }




    public GameObject pause;


    void Awake()

    {

        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }




    }



    void Start()
    {
        pause.SetActive(false);
    }

    void Update()
    {

    }





    public void GamePause()
    {
        Time.timeScale = 0;

        pause.SetActive(true);

    }


    public void GameRusume()
    {
        Time.timeScale = 1;

        pause.SetActive(false);

        //GameManagerScript.Instance().gamePause = false;

    }
}