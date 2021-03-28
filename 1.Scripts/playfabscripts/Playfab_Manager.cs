using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;


public class Playfab_Manager : MonoBehaviour
{
    
    public BtManager btManager;
    [Header("login")]
    public InputField IDinput, PWinput;
    [Header("singin")]
    public InputField singEmailinput, singPWinput, singNAMEinput;
    public string username;
    //public Text userName;
    //public PlayerLeaderboardEntry MyPlayFabInfo;
    //public List<PlayerLeaderboardEntry> PlayFabUserList = new List<PlayerLeaderboardEntry>();

    public void Awake()
    {
        if (btManager == null) { return; }
        //DontDestroyOnLoad(this);
    }
    #region 로그인 시스템
    public void LoginBt()
    {
        var request = new LoginWithEmailAddressRequest { Email = IDinput.text, Password = PWinput.text};
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

        
    }
    void OnLoginSuccess(LoginResult result)
    {
        
        
        //GetLeaderboard(result.PlayFabId);
        //PhotonNetwork.ConnectUsingSettings();
        //var request = new GetAccountInfoRequest { Username = username };
        //PlayFabClientAPI.GetAccountInfo(request, GetAccountSuccess,GetAccountFailure)
        Debug.Log("로그인 성공");
        PlayerPrefs.SetString("Username", username);

        GetAccountInfoRequest request = new GetAccountInfoRequest { Username = username };
        PlayFabClientAPI.GetAccountInfo(request, OnAccountSuccess, OnAccountFailure);
        SceneManager.LoadScene("My_game 1");
    }
    void OnAccountSuccess(GetAccountInfoResult result) 
    {
        string nickname = result.AccountInfo.TitleInfo.DisplayName;
        if (nickname == null)
        {
            return;
        }
        else 
        {
            PlayerPrefs.SetString("NickName", nickname);
            
            
        }
    }
    void OnAccountFailure(PlayFabError PlayFabError)
    {
        Debug.Log("닉네임 불러오기 실패");
    }
    void OnLoginFailure(PlayFabError error)
    {
        IDinput.text = "";
        PWinput.text = "";
        Debug.Log("로그인 실패");
    }
    #endregion

    #region 회원가입 시스템
    public void SinginBt()
    {
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest { Email = singEmailinput.text, Password = singPWinput.text, Username = singNAMEinput.text, DisplayName = singNAMEinput.text};
        PlayFabClientAPI.RegisterPlayFabUser(request, OnSinginSuccess, OnSinginFailure);
       
    }
    void OnSinginSuccess(RegisterPlayFabUserResult result)
    {

        username = singNAMEinput.text;
        btManager.Bt_manager("로그인");
        //GetLeaderboard(result.PlayFabId);
        //PhotonNetwork.ConnectUsingSettings();
        
        Debug.Log("회원가입 성공");
    }
    void OnSinginFailure(PlayFabError error)
    {
        Debug.Log("회원가입 실패");
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion
    //void SetStat() 
    //{
    //    var request = new UpdatePlayerStatisticsRequest { Statistics = new List<StatisticUpdate> { new StatisticUpdate { StatisticName = "IDinfo", Value = 0 } } };
    //    PlayFabClientAPI.UpdatePlayerStatistics(request, (result) => { }, (error) => print("값 저장실패"));
    //}


}

