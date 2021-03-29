using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class items
{
    public int itemindex;
    public string itemname;
    public string itemexplanation;
    public bool isitem = false;
    public Image skinitem;
}
[System.Serializable]
public class GameDataBassManager : MonoBehaviour
{
    #region 데이터
    public bool firstGame = true;

    #endregion
    #region 날짜
    public int year = 1483;
    public int month = 11;
    public int day = 23;
    #endregion
    #region 스테이터스
    public int ps = 10;
    public int tlp = 10;
    public int gorce = 10;
    public int decreasing = 10;
    public int Politics = 10;
    public int Charm = 10;
    public int Karma = 10;
    public int Fatigue = 10;
    #endregion
    #region 돈
    public int money = 1000;
    #endregion
    #region 아이템
    public items[] Items;
    #endregion
    #region 싱글톤
    private static GameDataBassManager instance = null;
    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }
    public static GameDataBassManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (firstGame)
        {
            ps = 10;
            tlp = 10;
            gorce = 10;
            decreasing = 10;
            Politics = 10;
            Charm = 10;
            Karma = 10;
            Fatigue = 10;
            money = 1000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
