using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    GameRoomManager gameRoomManager;

    // gooleSheetManager;
    public GameObject[] gamePenal = new GameObject[4];
    public GameObject[] Charactor;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject == null) 
        {
            return;
        }
        gameRoomManager = GameObject.Find("GameRoomManager").GetComponent<GameRoomManager>();
        //gooleSheetManager = GameObject.Find("GoogleSheetManager").GetComponent<GooleSheetManager>();
        gamePenal[0].SetActive(true);
        gamePenal[1].SetActive(false);
        gamePenal[2].SetActive(false);
        if (Charactor[0] != null)
        {
            Charactor[0].SetActive(true);
            Charactor[1].SetActive(false);
        }
        else 
        {
            return;
        }
        
        
        
        //gamePenal[3].SetActive(false);
    }
    
    public void buttonManager(string buttonName)
    {
        switch (buttonName) 
        {
            case "홈":
                gamePenal[0].SetActive(true);
                gamePenal[1].SetActive(false);
                gamePenal[2].SetActive(false);
                //gamePenal[3].SetActive(false);
                break;
            case "캐릭터":
                gamePenal[1].SetActive(true);
                gamePenal[0].SetActive(false);
                gamePenal[2].SetActive(false);
                //gamePenal[3].SetActive(false);
                break;
            case "튜토리얼":
                gamePenal[2].SetActive(true);
                gamePenal[1].SetActive(false);
                gamePenal[0].SetActive(false);
                //gamePenal[3].SetActive(false);
                break;
            case "설정":
                gamePenal[3].SetActive(true);
                gamePenal[1].SetActive(false);
                gamePenal[2].SetActive(false);
                //gamePenal[0].SetActive(false);
                break;
            case "종료":
                SceneManager.LoadScene("title3");
                //PlayerPrefs.DeleteAll();
                
                //gooleSheetManager.EndGamebt();
                break;
        }
    }
    public void buttonManager2(string buttonName)
    {
        switch (buttonName)
        {
            case "시작":
                gamePenal[0].SetActive(false);
                gamePenal[1].SetActive(true);
                gamePenal[2].SetActive(false);
                break;
            case "회원가입":
                gamePenal[0].SetActive(false);
                gamePenal[1].SetActive(false);
                gamePenal[2].SetActive(true);
                break;
            case "로그인":
                gamePenal[0].SetActive(false);
                gamePenal[1].SetActive(true);
                gamePenal[2].SetActive(false);
                break;
            case "뒤로가기":
                gamePenal[0].SetActive(false);
                gamePenal[1].SetActive(true);
                gamePenal[2].SetActive(false);
                break;
        }
    }
    public void charactorButton(string charactorName) 
    {
        switch (charactorName) 
        {
            case "천마":
                gameRoomManager.nChampionnum = 0;
                Charactor[0].SetActive(true);
                Charactor[1].SetActive(false);
                break;
            case "잔다르크":
                gameRoomManager.nChampionnum = 1;
                Charactor[1].SetActive(true);
                Charactor[0].SetActive(false);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
