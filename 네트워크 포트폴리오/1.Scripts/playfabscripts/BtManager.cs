using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtManager : MonoBehaviour
{
    public GameObject loginPenal, singinPenal, titielPenal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bt_manager(string btname) 
    {
        if(btname == "로그인")
        {
            singinPenal.SetActive(false);
            titielPenal.SetActive(false);
            loginPenal.SetActive(true);
        }
        if (btname == "회원가입")
        {
            singinPenal.SetActive(true);
            titielPenal.SetActive(false);
            loginPenal.SetActive(false);
        }
        if (btname == "타이틀")
        {
            singinPenal.SetActive(false);
            titielPenal.SetActive(true);
            loginPenal.SetActive(false);
        }
    }
}
