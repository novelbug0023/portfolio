using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public class GoogleData2
{
    public string order, result, msg, name2;
    public int gamemoney, realmoney, lv, openslot, closeslot, admeyn;
    public float exp;
}
public class GameManager : MonoBehaviour
{
    #region 구글
    private static GameManager instance;
    public static GameObject container;
    public static GameManager GetInstance() 
    {
        if (!instance) 
        {
            container = new GameObject();
            container.name = "GameManager";
            instance = container.AddComponent(typeof(GameManager)) as GameManager;
        }
        return instance;
    }

    //const string URL = "https://script.google.com/macros/s/AKfycbyb6ojRgcStyHsxSzParldfYCXlU5WL_ynFq-wuVVPE6XCdQJG7-eM/exec";
    public GoogleData2 GD;
    //public UserData userData;
    [Header("홈 정보")]
    public Text NickNAME;
    public string Name;
    public int gamemoney, realmoney, lv, openslot, closeslot, admeyn;
    public float exp;
    public Text userLV;
    public Text gameMoney;
    public Text realMoney;
    public Image expbar;
    public float intiExp = 1.0f;
    //public float exp;
    [Header("캐릭터 정보")]
    public int charactorNum;
    public GameObject charctorSlot;
    public Transform slotPos;


    //// Start is called before the first frame update
    //////void Start()
    ////{

    ////}
    //void Start()
    //{
    //    GetValue();
    //    //name = PlayerPrefs.GetString("NICK");
    //    //gamemoney= PlayerPrefs.GetInt("MONRY");
    //    //realmoney = PlayerPrefs.GetInt("REALMO");
    //    //exp = PlayerPrefs.GetFloat("EXP");
    //    //lv = PlayerPrefs.GetInt("LV");
    //    //openslot = PlayerPrefs.GetInt("OPENSLOT");
    //    //closeslot = PlayerPrefs.GetInt("CLOSESLOT");
    //    //admeyn = PlayerPrefs.GetInt("ADMEYN");

    //    //NickNAME.text = Name;

    //}
    ////private void Update()
    ////{
    ////    //데이터 세이브

    ////    //DontDestroyOnLoad(this);
    ////    //게임 시스템
    ////    userLV.text = lv.ToString();
    ////    gameMoney.text = gamemoney.ToString();
    ////    realMoney.text = realmoney.ToString();
    ////    expbar.fillAmount = exp / intiExp;
    ////    //

    ////}
    //IEnumerator GetPost(WWWForm form)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.isDone) { Response(www.downloadHandler.text); }
    //        else print("웹이 응답이 없습니다.");
    //    }

    //}
    //public void GetValue()
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("order", "getValue");

    //    StartCoroutine(GetPost(form));
    //}
    //private void Update()
    //{
    //    NickNAME.text = Name;
    //    userLV.text = lv.ToString();
    //    gameMoney.text = gamemoney.ToString();
    //    realMoney.text = realmoney.ToString();
    //    expbar.fillAmount = exp / intiExp;

    //}
    //void Response(string json)
    //{
    //    if (string.IsNullOrEmpty(json)) return;

    //    GD = JsonUtility.FromJson<GoogleData2>(json);

    //    if (GD.result == "ERROR")
    //    {
    //        print(GD.order + "을 실행할 수 없습니다. 에러 메시지 : " + GD.msg);
    //        return;
    //    }

    //    print(GD.order + "을 실행했습니다. 메시지 : " + GD.msg);

    //    if (GD.order == "getValue")
    //    {

    //        gamemoney = GD.gamemoney;
    //        realmoney = GD.realmoney;
    //        exp = GD.exp;
    //        lv = GD.lv;
    //        openslot = GD.openslot;
    //        closeslot = GD.closeslot;
    //        admeyn = GD.admeyn;
    //        Name = GD.name2;
    //        PlayerPrefs.SetString("NICK", Name.Trim());
    //        PlayerPrefs.SetInt("MONRY", gamemoney);
    //        PlayerPrefs.SetInt("REALMO", realmoney);
    //        PlayerPrefs.SetFloat("EXP", exp);
    //        PlayerPrefs.SetInt("LV", lv);
    //        PlayerPrefs.SetInt("OPENSLOT", openslot);
    //        PlayerPrefs.SetInt("CLOSESLOT", closeslot);
    //        PlayerPrefs.SetInt("ADMEYN", admeyn);
    //        PlayerPrefs.Save();

    //    }
    //}



    // Update is called once per frame
    #endregion

    //public Text userName;
    
}
