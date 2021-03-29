using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchedulesystemManager : MonoBehaviour
{
    #region 싱글톤
    private static SchedulesystemManager instance = null;
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
    public static SchedulesystemManager Instance
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
    ScheduleBtManager schedulebt;
    GameDataBassManager db;

    public string schdule;
    public int schdulenum;
    public string[] schdules;

    int Calendar = 365;

    

    List<string> schdulesList = new List<string>();
    public GameObject schdulesboxs;
    public GameObject schdulesboxsnull;
    public GameObject Calendars;
    public GameObject[] schdulesLayers;
    List<GameObject> schdulesbox= new List<GameObject>();
    //=================================================
    //bool isleapyeaar;

    // Start is called before the first frame update
    void Start()
    {
        schedulebt = GameObject.Find("schdulebt").GetComponent<ScheduleBtManager>();
        db = GameObject.Find("databass").GetComponent<GameDataBassManager>();
        
    }
    public void StartCalendar()
    {
        isleapyeaar(db.year);
        lastDay(db.year, db.month);
        totalDay(db.year, db.month, db.day);
        wickday(db.year, db.month, db.day);
        //Debug.Log(db.year+"년"+db.month+"월\n");
        //Debug.Log("일    월   화   수   목   금   토\n");
        for (int i = 0; i < wickday(db.year, db.month, 1); i++)
        {
            //Debug.Log("");
            schdulesLayers[i] = Instantiate(schdulesboxsnull);
            schdulesLayers[i].transform.SetParent(Calendars.transform);
            schdulesLayers[i].transform.localPosition = Vector3.zero;
            
            //Calendars.transform.parent = schdulesLayers[i].transform.position;
            //obj.transform.parent = FindObjectOfType<Canvas>().transform;
        }
        for (int i = 0; i < lastDay(db.year, db.month)+1; i++)
        {
            
            if (i == schdulesLayers.Length)
            {
                break;
            }
            schdulesLayers[i] = Instantiate(schdulesboxs);
            //Calendars.transform.position = schdulesLayers[i].transform.position;
            schdulesLayers[i].transform.SetParent(Calendars.transform);
            schdulesLayers[i].transform.localPosition = Vector3.zero;
            schdulesLayers[i].GetComponentInChildren<Text>().text = (1 + i).ToString();
            Debug.Log(i);
            if (wickday(db.year, db.month, i) == 6 && lastDay(db.year, db.month) != i)
            {
                Debug.Log("\n");
            }
        }
    }
    public bool isleapyeaar(int year)
    {
        //year = db.year;
        return db.year % 4 == 0 && db.year % 100 != 0 || db.year % 400 == 0;
    }
    public int lastDay(int year, int month)
    {
        //month = db.month;
        int[] m = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        m[1] = isleapyeaar(year) ? 29 : 28;
        return m[month - 1];
    }
    public int totalDay(int year, int month, int day)
    {
        int total = (year - 1) * 365 + (year - 1) / 4 - (year - 1) / 100 + (year - 1) / 400;
        for (int i = 1; i < month; i++)
        {
            total += lastDay(year, i);
        }
        return total + day;
    }
    public int wickday(int year, int month, int day)
    {
        return totalDay(year, month, day) % 7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void schdulesStart()
    {

    }
    public void addSchdules()
    {
        for (int i = 0; i <= lastDay(db.year, db.month) + 1; i++)
        {
            for (int j = 0; j <= 8; j++)
            {
                schdulesList.Add(schdule);
            
            }
        }
        

    }
}
