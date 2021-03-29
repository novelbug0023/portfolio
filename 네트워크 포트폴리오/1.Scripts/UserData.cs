using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class UserData : MonoBehaviour
{
    [System.Serializable]
    public class userDB 
    {
        public string sUserId;
        public string sUserPw;
        public string sUsername;
    }
    public List<userDB> userdB = new List<userDB>();
    
    [Header("회원정보")]
    public string[] SUserID;
    public string[] SUserPw;
    public string[] SUserNickname;
    public int IDMembercount;
    

    [Header("유저 데이터 베이스")]
    public string UserID;
    public string UserPw;
    public int MYNUM;
    public string nickname;
    public int coin;
    public int Jewelry;
    public int UserLv;
    public float currexp = 0.0f;

    [Header("케릭터 데이터 베이스")]
    public int charactorNum;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        nickname = "";
        //userdb = GetComponent<UserData.userDB>();
        DontDestroyOnLoad(this.gameObject);
        //UserID = PlayerPrefs.GetString("USER_ID");
        //UserPw = PlayerPrefs.GetString("USER_PW");
        coin = PlayerPrefs.GetInt("coin");
        Jewelry = PlayerPrefs.GetInt("Jewelry");
        UserLv = PlayerPrefs.GetInt("UserLv");
        charactorNum = PlayerPrefs.GetInt("charactorNum");
        IDMembercount = PlayerPrefs.GetInt("SIDINT");
        currexp = PlayerPrefs.GetFloat("UserEXP");
        for (int i = 0; i < SUserNickname.Length + 1;i++) 
        {
            SUserNickname[i] = PlayerPrefs.GetString("NickName");
        }
        


        var data = PlayerPrefs.GetString("UserdB");

        if (!string.IsNullOrEmpty(data))
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream(Convert.FromBase64String(data));

            // 가져온 데이터를 바이트 배열로 변환하고
            // 사용하기 위해 다시 리스트로 캐스팅해줍니다.
            userdB = (List<userDB>)binaryFormatter.Deserialize(memoryStream);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        //PlayerPrefs.SetString("USER_NICK", nickname);
        
        PlayerPrefs.SetInt("MYUSERNUM", MYNUM);
        
        PlayerPrefs.SetInt("COIN", coin);
        PlayerPrefs.SetInt("JEWELRY", Jewelry);
        PlayerPrefs.SetInt("USER_LV", UserLv);
        PlayerPrefs.SetInt("CHARACTOR_NUM", charactorNum);
        PlayerPrefs.SetInt("IDM", IDMembercount);
        PlayerPrefs.SetInt("SIDINT", SUserID.Length);

        PlayerPrefs.SetFloat("USER_EXP", currexp);
        //==========================================
        var binaryFormatter = new BinaryFormatter();
        var memoryStrem = new MemoryStream();

        binaryFormatter.Serialize(memoryStrem, userdB);
        PlayerPrefs.SetString("UserdB", Convert.ToBase64String(memoryStrem.GetBuffer()));




        PlayerPrefs.Save();
        

    }
}
