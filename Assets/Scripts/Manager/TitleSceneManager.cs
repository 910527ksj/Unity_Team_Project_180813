using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public int _lobbyStateIndex;
    public GameObject Naming;
    public UIInput NamingTX;
    public GameObject MainUI;
    public AudioClip titleMusic;
    
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        SoundManager.Instance.PlayMusic(titleMusic);

        
    }

    void Update()
    {

    }

    public void NamingOn()
    {
        if (!PlayerPrefs.HasKey("playerName"))
        {
            Naming.SetActive(true);
            MainUI.SetActive(false);
        }
        else
        {
            _lobbyStateIndex = 0;
            SaveLobbyIndex();

            SceneManager.LoadScene(1);
        }
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
        PlayerPrefs.SetString("playerName", NamingTX.value);
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

}