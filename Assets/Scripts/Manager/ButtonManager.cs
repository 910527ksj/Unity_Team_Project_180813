using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject worldSelectWindow;
    public GameObject stageSelectWindow;
    public GameObject inventoryWindow;

    public int _lobbyStateIndex;
    public AudioClip lobbyMusic;

    void Start()
    {
        LoadLobbyIndex();

        SoundManager.Instance.PlayMusic(lobbyMusic);

        if (_lobbyStateIndex == 0)
        {
            CloseWorldSelectWindow();
        }

        if (_lobbyStateIndex == 1)
        {
            OpenWorldSelectWindow();
            //OpenStageSelectWindow();

        }


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


    public void OpenWorldSelectWindow()
    {
        worldSelectWindow.SetActive(true);
        _lobbyStateIndex = 1;

        SaveLobbyIndex();
        
        //Debug.Log("_lobbyStateIndex : " + _lobbyStateIndex);
    }

    public void CloseWorldSelectWindow()
    {
        worldSelectWindow.SetActive(false);
        _lobbyStateIndex = 0;
        SaveLobbyIndex();

        //Debug.Log("_lobbyStateIndex : " + _lobbyStateIndex);
    }

    public void OpenStageSelectWindow()
    {
        stageSelectWindow.SetActive(true);

       
    }

    public void CloseStageSelectWindow()
    {
        stageSelectWindow.SetActive(false);
    }


    public void LoginLobby()
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

    public void OpenInvenWindow()
    {
        inventoryWindow.SetActive(true);


    }

    public void CloseInvenWindow()
    {
        inventoryWindow.SetActive(false);


    }

}