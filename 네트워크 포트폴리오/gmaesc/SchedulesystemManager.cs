using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchedulesystemManager : MonoBehaviour
{
    #region �̱���
    private static SchedulesystemManager instance = null;
    void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
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
        //Debug.Log(db.year+"��"+db.month+"��\n");
        //Debug.Log("��    ��   ȭ   ��   ��   ��   ��\n");
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
