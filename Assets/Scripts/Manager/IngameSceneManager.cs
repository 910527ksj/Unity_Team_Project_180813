using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameSceneManager : MonoBehaviour
{
   
    public int _lobbyStateIndex;
    public AudioClip world01Music;
    public GameObject optionWindow;


    void Start()
    {

        SoundManager.Instance.PlayMusic(world01Music);

    }

    void Update()
    {

    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;

        }


    }

    public void ToIngameShowAD()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;

        }


        //AdManager.Instance().FreeGemBtn();
        SceneManager.LoadScene(2);



    }

    public void ToIngame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;

        }


        //AdManager.Instance().FreeGemBtn();
        SceneManager.LoadScene(2);



    }

    public void ToLobby()
    {
        SceneManager.LoadScene(1);
        //Debug.Log("로비로이동하기");
    }


    public void StageClearToLobby()
    {
        //AdManager.Instance().ShowAd();
        SceneManager.LoadScene(1);
        //Debug.Log("스테이지클리어후로비로이동하기");
    }

    public void GameQuit()
    {
        Application.Quit();
    }



    public void ReturnWorldSelectWindow()
    {
        _lobbyStateIndex = 1;
        SaveLobbyIndex();

        SceneManager.LoadScene(1);
    }

    public void ReturnLobbyWindow()
    {
        _lobbyStateIndex = 0;
        SaveLobbyIndex();

        SceneManager.LoadScene(1);
    }
        
    public void SaveLobbyIndex()
    {
        PlayerPrefs.SetInt("LobbyStateIndex", _lobbyStateIndex);
    }
    public void LoadLobbyIndex()
    {
        _lobbyStateIndex = PlayerPrefs.GetInt("LobbyStateIndex", _lobbyStateIndex);
    }

    public void OpenOptionWindow()
    {
        optionWindow.SetActive(true);
    }

    public void CloseOptionWindow()
    {
        optionWindow.SetActive(false);
    }
}


