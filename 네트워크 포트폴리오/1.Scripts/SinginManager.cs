using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SinginManager : MonoBehaviour
{
    [Header("회원 가입")]
    public UserData userData;
    public InputField idField;
    public InputField pwField;
    public InputField _Nicname;
    public GameObject SinginPenal;
    // Start is called before the first frame update
    void Start()
    {
        userData = GameObject.Find("UserData").GetComponent<UserData>();
    }

    // Update is called once per frame
    void Update()
    {

    }
  
    public void Singinbt() 
    {
        if (userData.userdB.Count == -1)
        {
            userData.userdB.Add(new UserData.userDB
            { sUserId = idField.text, sUserPw = pwField.text, sUsername = _Nicname.text });
        }
        else
        {
            for (int i = 0; i < userData.userdB.Count; i++)
            { 
                if (userData.userdB[i].sUserId != idField.text && userData.userdB[i].sUsername != _Nicname.text)
                {
                    userData.userdB.Add(new UserData.userDB
                    { sUserId = idField.text, sUserPw = pwField.text, sUsername = _Nicname.text });
                }
                else if (userData.userdB[i].sUserId == idField.text || userData.userdB[i].sUsername == _Nicname.text)
                {
                    Debug.Log("같은 아이디또는 닉네임이 존재 합니다.");
                    break;
                }
            }
        }
        //userData.userdB.Add(new UserData.userDB 
        //{ sUserId = idField.text, sUserPw = pwField.text,sUsername = _Nicname.text});
        //============================================================================
        //var binaryFormatter = new BinaryFormatter();
        //var memoryStrem = new MemoryStream();

        //binaryFormatter.Serialize(memoryStrem, userData.userdB);
        //PlayerPrefs.SetString("UserdB", Convert.ToBase64String(memoryStrem.GetBuffer()));
    }
    public void singinColsebutton()
    {
        SinginPenal.SetActive(false);
    }
}
