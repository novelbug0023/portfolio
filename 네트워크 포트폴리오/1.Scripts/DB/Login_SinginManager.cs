using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Login_SinginManager : MonoBehaviour
{
    [Header("로그인")]
    public InputField EmailField;
    public InputField PwField;
    [Header("회원 가입")]
    public InputField _EmailField;
    public InputField _PwField;
    public InputField _Nicname;
    public GameObject SinginPenal;

    [Header("BD_URL")]
    public string LoginUrl;
    public string SinginUrl;

    // Start is called before the first frame update
    void Start()
    {
        LoginUrl = "nbstudio.000webhostapp.com/Login.php";
        SinginUrl = "nbstudio.000webhostapp.com/Singin.php";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loginbutton() 
    {
        Debug.Log("로그인버튼");
        StartCoroutine("LoginColrutin");
    }
    IEnumerator LoginColrutin() 
    {
        Debug.Log(EmailField.text);
        Debug.Log(PwField.text);

        WWWForm form = new WWWForm();
        form.AddField("EMAIL", EmailField.text);
        form.AddField("PW", PwField.text);

        WWW WebRequcsl = new WWW(LoginUrl, form);
        
        yield return WebRequcsl;
        Debug.Log(WebRequcsl.text);

        //yield return null;
    }
    public void singinopenbutton()
    {
        SinginPenal.SetActive(true);
    }
    public void singinbutton()
    {
        StartCoroutine("singinColrutin");
    }
    IEnumerator singinColrutin()
    {
        Debug.Log(_EmailField.text);
        Debug.Log(_PwField.text);

        WWWForm form = new WWWForm();
        form.AddField("EMAIL", _EmailField.text);
        form.AddField("PW", _PwField.text);
        form.AddField("NICNAME", _Nicname.text);
        form.AddField("INFO", "어서오세요" + _Nicname.text+"성좌님");

        WWW WebRequcsl = new WWW(SinginUrl, form);

        yield return WebRequcsl;
        Debug.Log(WebRequcsl.text);
    }
}
