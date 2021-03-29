using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;


[System.Serializable]
public class GoogleData
{
    public string order, result, msg, name2;
    public int gamemoney, realmoney, lv, openslot, closeslot, admeyn;
    public float exp;
}
public class GooleSheetManager : MonoBehaviour
{
    GooleSheetManager instance;
    const string URL = "https://script.google.com/macros/s/AKfycbyb6ojRgcStyHsxSzParldfYCXlU5WL_ynFq-wuVVPE6XCdQJG7-eM/exec";
    public GoogleData GD;
    //IEnumerator Start() 
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("value", "값");
    //    form.AddField("value", "값");
    //    form.AddField("value", "값");

    //    UnityWebRequest www = UnityWebRequest.Post(URL, form);
    //    yield return www.SendWebRequest();

    //    string data = www.downloadHandler.text;
    //    print(data);
    //}

    public InputField IDInput, PwInput, NameInput, PhonNumInput;
    public InputField IDInput2, PwInput2;
    public string id, pass, Name, phon ;
    public float Exp;
    public int Gamemoney, Realmoney, Lv, Openslot, Closeslot, Admeyn;
    public bool dataSave = false;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;

    }
    public void Start()
    {
        dataSave = false;
    }

    bool SetIDPW()
    {
        //Debug.Log("아이디 또는 비밀번호가 비었습니다.");
        id = IDInput.text.Trim();
        pass = PwInput.text.Trim();
        Name = NameInput.text.Trim();
        phon = PhonNumInput.text.Trim();

        if (id == "" || pass == "") return false;
        else return true;
    }
    bool SetIDPW2()
    {
        //Debug.Log("아이디 또는 비밀번호가 비었습니다.");
        id = IDInput2.text.Trim();
        pass = PwInput2.text.Trim();
        

        if (id == "" || pass == "") return false;
        else return true;
    }
    public void Register()
    {
        Debug.Log("회원가입");
        if (!SetIDPW())
        {
            print("아이디 또는 비밀번호가 비었습니다.");
            return;
        }
        WWWForm form = new WWWForm();

        form.AddField("order", "register");
        form.AddField("id", id);
        form.AddField("pass", pass);
        form.AddField("name", Name);
        form.AddField("phon", phon);
        form.AddField("gmaemoney2", 0);
        form.AddField("realmoney2", 0);
        form.AddField("exp2", 0);
        form.AddField("lv2", 1);
        form.AddField("openslot2", 1);
        form.AddField("closeslot2", 1);
        form.AddField("admeyn2", 0);

        StartCoroutine(Post(form));
    }
    void OnApplicationQuit() 
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "logout");
        StartCoroutine(Post(form));
    }
    public void EndGamebt() 
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "logout");
        StartCoroutine(Post(form));
        PlayerPrefs.DeleteAll();
    }
    IEnumerator Post(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone) { } //print(www.downloadHandler.text);
            else print("웹이 응답이 없습니다.");
        }

    }
    //IEnumerator GetPost(WWWForm form)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.isDone) { Response(www.downloadHandler.text);}
    //        else print("웹이 응답이 없습니다.");
    //    }

    //}
    IEnumerator Post2(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone) 
            { 
                print(www.downloadHandler.text); 
                
                SceneManager.LoadScene("My_game"); dataSave = true; /*GetValue(); */
            }
            else print("웹이 응답이 없습니다.");
        }

    }

    public void Login() 
    {
        if (!SetIDPW2())
        {
            print("아이디 또는 비밀번호가 비어있습니다.");
            return;
        }
        WWWForm form = new WWWForm();
        form.AddField("order", "login");
        form.AddField("id", id);
        form.AddField("pass", pass);
        //form.AddField("name", Name);

        StartCoroutine(Post2(form));
        
    }
    public void SetValue()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "gameMoneysetValue");
        form.AddField("order", "realmoneysetValue");
        form.AddField("order", "expsetValue");
        form.AddField("order", "lvValue");
        form.AddField("order", "openslotValue");
        //form.AddField("order", "closeslotValue");
        form.AddField("gamemoney", Gamemoney);
        form.AddField("realmoney", Realmoney);
        form.AddField("exp", Exp.ToString());
        form.AddField("lv", Lv.ToString());
        form.AddField("openslot", Openslot.ToString());

        StartCoroutine(Post(form));
    }
    private void Update()
    {
        if (dataSave)
        {
            SetValue();
        }
    }

    //public void GetValue()
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("order", "getValue");

    //    StartCoroutine(GetPost(form));
    //}
    //private void Update()
    //{
    //    PlayerPrefs.SetString("NICK", Name.Trim());
    //    PlayerPrefs.SetInt("MONRY", Gamemoney);
    //    PlayerPrefs.SetInt("REALMO", Realmoney);
    //    PlayerPrefs.SetFloat("EXP", Exp);
    //    PlayerPrefs.SetInt("LV", Lv);
    //    PlayerPrefs.SetInt("OPENSLOT", Openslot);
    //    PlayerPrefs.SetInt("CLOSESLOT", Closeslot);
    //    PlayerPrefs.SetInt("ADMEYN", Admeyn);
    //    PlayerPrefs.Save();
    //    if (dataSave) 
    //    {
    //        SetValue(); 
    //    }
    //    //SetValue();
    //}
    //void Response(string json)
    //{
    //    if (string.IsNullOrEmpty(json)) return;

    //    GD = JsonUtility.FromJson<GoogleData>(json);

    //    if (GD.result == "ERROR")
    //    {
    //        print(GD.order + "을 실행할 수 없습니다. 에러 메시지 : " + GD.msg);
    //        return;
    //    }

    //    print(GD.order + "을 실행했습니다. 메시지 : " + GD.msg);

    //    if (GD.order == "getValue")
    //    {

    //        Gamemoney = GD.gamemoney;
    //        Realmoney = GD.realmoney;
    //        Exp = GD.exp;
    //        Lv = GD.lv;
    //        Openslot = GD.openslot;
    //        Closeslot = GD.closeslot;
    //        Admeyn = GD.admeyn;
    //        Name = GD.name2;
    //        PlayerPrefs.SetString("NICK", Name.Trim());
    //        PlayerPrefs.SetInt("MONRY", Gamemoney);
    //        PlayerPrefs.SetInt("REALMO", Realmoney);
    //        PlayerPrefs.SetFloat("EXP", Exp);
    //        PlayerPrefs.SetInt("LV", Lv);
    //        PlayerPrefs.SetInt("OPENSLOT", Openslot);
    //        PlayerPrefs.SetInt("CLOSESLOT", Closeslot);
    //        PlayerPrefs.SetInt("ADMEYN", Admeyn);
    //        PlayerPrefs.Save();

    //    }
    //}


}
