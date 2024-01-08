using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelecteManager : MonoBehaviour
{

    static CharacterSelecteManager _instance = null;

    public static CharacterSelecteManager Instance()
    {

        return _instance;

    }


    public int _playerIndex;



    //public int curplayerIndex;
    //public int curplayerIndex;
    //public int curstageIndex;
    public UILabel playerNameTxt;
    

    public GameObject Lobbyplayer01;
    public GameObject Lobbyplayer02;
    public GameObject Lobbyplayer03;
    public GameObject Lobbyplayer04;


    public int playerIndex
    {
        get
        {
            return _playerIndex;
        }
        set
        {
            _playerIndex = value;
        }
    }


    private void Awake()
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
       // PlayerPrefs.DeleteAll();
        
        LoadPlayerIndex();
        //Debug.Log("playerIndex : " + _playerIndex);

    }


    void Update()
    {

       


    }



    public void CharacterSelectRightBtn()
    {
        
        if (_playerIndex >= 3)
        {

            _playerIndex = 3;
        }
        else
        {
            _playerIndex += 1;
        }

        playerIndexChanger();
        //Debug.Log("playerIndex : " + _playerIndex);


        SavePlayerIndex();


    }

    public void CharacterSelectLeftBtn()
    {

        if (_playerIndex <= 0)
        {
            _playerIndex = 0;
        }
        else
        {
            _playerIndex -= 1;
        }

        playerIndexChanger();
        //Debug.Log("playerIndex : " + _playerIndex);


        SavePlayerIndex();
    }



    void playerIndexChanger()
    {
        //============================캐릭터 선택=================================================//

        if (_playerIndex == 0)
        {
            //Instantiate(Lobbyplayer01, transform.position, transform.rotation);

            Lobbyplayer01.SetActive(true);
            Lobbyplayer02.SetActive(false);
            Lobbyplayer03.SetActive(false);
            Lobbyplayer04.SetActive(false);
            playerNameTxt.text = "검사";

        }


        if (_playerIndex == 1)
        {
            //Instantiate(Lobbyplayer02, transform.position, transform.rotation);

            Lobbyplayer01.SetActive(false);
            Lobbyplayer02.SetActive(true);
            Lobbyplayer03.SetActive(false);
            Lobbyplayer04.SetActive(false);
            playerNameTxt.text = "궁사";

        }


        if (_playerIndex == 2)
        {
            //Instantiate(Lobbyplayer03, transform.position, transform.rotation);
            Lobbyplayer01.SetActive(false);
            Lobbyplayer02.SetActive(false);
            Lobbyplayer03.SetActive(true);
            Lobbyplayer04.SetActive(false);
            playerNameTxt.text = "격투사";

        }


        if (_playerIndex == 3)
        {
            //Instantiate(Lobbyplayer04, transform.position, transform.rotation);
            Lobbyplayer01.SetActive(false);
            Lobbyplayer02.SetActive(false);
            Lobbyplayer03.SetActive(false);
            Lobbyplayer04.SetActive(true);
            playerNameTxt.text = "사제";

        }

    }

   



    void SavePlayerIndex()

    {

        PlayerPrefs.SetInt("PlayerIndex", _playerIndex);
        //Debug.Log("_playerIndex저장성공 : " + _playerIndex);

    }
    

    void LoadPlayerIndex()
    {

        _playerIndex = PlayerPrefs.GetInt("PlayerIndex", _playerIndex);
        //Debug.Log("_playerIndex로드성공 : " + _playerIndex);

       
        if (_playerIndex == 0 || _playerIndex == null)
        {
            _playerIndex = 0;
            Lobbyplayer01.SetActive(true);
            playerNameTxt.text = "검사";
        }
        if (_playerIndex == 1)
        {
            _playerIndex = 1;
            Lobbyplayer02.SetActive(true);
            playerNameTxt.text = "궁사";
        }
        if (_playerIndex == 2)
        {
            _playerIndex = 2;
            Lobbyplayer03.SetActive(true);
            playerNameTxt.text = "격투사";
        }
        if (_playerIndex == 3)
        {
            _playerIndex = 3;
            Lobbyplayer04.SetActive(true);
            playerNameTxt.text = "사제";
        }

        

    }




}