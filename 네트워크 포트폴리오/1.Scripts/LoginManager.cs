using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginManager : MonoBehaviour
{
    [Header("회원 가입")]
    public UserData userData;
    public UserData.userDB userdb;
    public InputField idField;
    public InputField pwField;
    public GameObject SinginPenal;
    // Start is called before the first frame update
    void Start()
    {
        userData = GameObject.Find("UserData").GetComponent<UserData>();
        //userdb = GameObject.Find("UserData").GetComponent<UserData.userDB>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void singinopenbutton()
    {
        SinginPenal.SetActive(true);
    }
    public void LoginBT()
    {
        Debug.Log("로그인");
        for (int i = 0; i < userData.userdB.Count; i++) 
        {
            if (userData.userdB[i].sUserId == idField.text && userData.userdB[i].sUserPw == pwField.text)
            {
                Debug.Log("로그인접근");
                userData.MYNUM = PlayerPrefs.GetInt("MYUSERNUM");
                userData.nickname = userData.userdB[i].sUsername;
                SceneManager.LoadScene("My_game");
                if (i > userData.userdB.Count) 
                {
                    return;
                }
                //userData.nickname = 
            }
            else if (userData.userdB[i].sUserId != idField.text || userData.userdB[i].sUserPw != pwField.text)
            {
                Debug.Log("아이디 또는 비밀번호가 일치 하지 안습니다.");
                if (i > userData.userdB.Count)
                {
                    return;
                }
            }
            
        }



    }
}
