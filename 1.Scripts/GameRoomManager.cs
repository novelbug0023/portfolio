using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

//public class UserData3
//{
//    //클라이언트가 접속할 때에 어느쪽도 정의 가 안되어 있는 겨우에는 유저ID를 송신하지 않습니다,
//    //Photon Sever는 그 경우 gui를 송싱하지 안습니다.
//    //userID가 클라이언트로 부터 접속시에 송신되느 경우,
//    //PhotonNetWork.AutoValues, NickName.PlayerName은 입실시레 송신 됩니다.

//    public int nActerNumber;
//    public int nChampionnum;

//    //public string sUserID;
//    public string sNickNmae;
//    public bool bMasterClient;

//    //게임 정보
//    public bool bReady;
//    //public int nSlotNum;
//    public int nChamPionNum;

//    //초기화
//    public UserData3(int _nActorNumber,int _nChamPionNum)
//    {
//        this.nActerNumber = _nActorNumber;
//        this.nChamPionNum = _nChamPionNum;
//    }
//    public UserData3(UserData3 C)
//    {
//        this.nActerNumber = C.nActerNumber;
//        this.nChamPionNum = C.nChamPionNum;
//        //this.nChamPionNum = C.nChamPionNum;

//    }
//    public void Clear()
//    {
//        this.nActerNumber = 0;
//        this.nChamPionNum = 0;
//    }
//}

public class GameRoomManager : MonoBehaviourPunCallbacks
{
    GameManager gameManager;
    public int nChampionnum;
    public int[] nActorNumBer;



    //유저 데이터 저장
    //private UserData3[] userDatas = new UserData3[]
    //{
    //    new UserData3(0,0)
    //};

    //채팅 관련
    //public Text msgList;
    //public InputField ifSendMsg;
    //public Text PlayerCount;

    //게임 정보
    [Header("게임 정보")]
    public int nMyActorNumber;

    //[Header("게임 데이터")]
    //public GameObject GameUserData; // 게임 유조 데이터 게임 오브젝트.

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("UserData").GetComponent<GameManager>();
        //내정보 업데이트
        //PhotonNetwork.NickName = gameManager.Name;
        if (photonView.IsMine) { return; }
        
        nMyActorNumber = PhotonNetwork.LocalPlayer.ActorNumber; //나의 접속 번호(나름 고유 번호)
    }
    private void Update()
    {
        PlayerPrefs.SetInt("CHAMPION_NUM", nChampionnum);
        PlayerPrefs.Save();
        
    }




}
