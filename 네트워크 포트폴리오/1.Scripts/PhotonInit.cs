using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;



public class PhotonInit : MonoBehaviourPunCallbacks
{
    GameManager gameManager;
    //public Playfab_Manager playfab_Manager;

    private string gameVersion = "1.0";
    private string UserID = "Test";
    //public int MaxPlayer = 10;
    public byte maxPlayer = 10;
    public Text userName;
    public bool isLoaded;
    // Start is called before the first frame update
    void Start()
    {
        //playfab_Manager = GameObject.Find("PlayFabManager").GetComponent<Playfab_Manager>();
        gameManager = GameObject.Find("UserData").GetComponent<GameManager>();
        PhotonNetwork.GameVersion = this.gameVersion;
        PhotonNetwork.NickName = PlayerPrefs.GetString("NICK");
        PhotonNetwork.ConnectUsingSettings();
        //PlayerPrefs.SetString("USER_ID", PhotonNetwork.NickName);
    }
    public void OnJoinRandomRoomClick()
    {
        PhotonNetwork.JoinRandomRoom();

    }
    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("접속연결");
        PhotonNetwork.JoinLobby();

    }
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log("랜덤 룸 접속");
        PhotonNetwork.IsMessageQueueRunning = false;
        SceneManager.LoadScene("play");
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("로비 접속");
        //if (isLoaded)
        //{
        //    ShowUserNickName();
        //}
        //else 
        //{
        //    Invoke("OnJoindLobbyDelay", 1);
        //}
    }
    //void OnJoindLobbyDelay() 
    //{
    //    isLoaded = true;
    //    PhotonNetwork.LocalPlayer.NickName = playfab_Manager.MyPlayFabInfo.DisplayName;
    //    ShowUserNickName();
    //}
    //void ShowUserNickName() 
    //{
    //    userName.text = "";
    //    for (int i = 0; i < playfab_Manager.PlayFabUserList.Count; i++) userName.text += playfab_Manager.PlayFabUserList[i].DisplayName + "\n";
    //}
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("랜덤 룸 접속 실패");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayer });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
