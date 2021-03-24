using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleBtManager : MonoBehaviour
{
    #region 싱글톤
    private static ScheduleBtManager instance = null;
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
    public static ScheduleBtManager Instance
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
    public SchedulesystemManager schdulesManager;
    public GameObject schdulesKinds;
    public int kindnum;
    public GameObject boxpos;
    public GameObject[] BOX;

    // Start is called before the first frame update
    void Start()
    {
        schdulesManager = GameObject.Find("schduleManager").GetComponent<SchedulesystemManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void schedulebt(string btName)
    {
        switch (btName)
        {
            case "취소":
                //schdulesManager

                break;
            case "초기화":
                //schdulesManager

                break;
            case "실행":

                break;
            case "수련":
                schdulesManager.schdule = btName;
                kindnum = 3;
                BOX = new GameObject[kindnum];
                make();


                //schdulesKinds = new GameObject[3];
                //schdulesManager.schdule = btName;
                break;
            case "학습":
                schdulesManager.schdule = btName;
                kindnum = 4;
                BOX = new GameObject[kindnum];
                make();


                //schdulesKinds = new GameObject[4];
                //schdulesManager.schdule = btName;
                break;
            case "휴식":
                schdulesManager.schdule = btName;
                kindnum = 2;
                BOX = new GameObject[kindnum];
                make();


                //schdulesKinds = new GameObject[2];
                //schdulesManager.schdule = btName;
                break;
        }
    }
    public void make()
    {
        Debug.Log("스케줄 생성");
        for (int i = 0; i < kindnum; i++)
        {
            //BOX = new GameObject[i];
            if (i == BOX.Length) { break; }
            Destroy(BOX[i].gameObject);
            BOX[i] = Instantiate(schdulesKinds);
            BOX[i].transform.SetParent(boxpos.transform);
            BOX[i].transform.localPosition = Vector3.zero;
            
        }
        for (int i = 0; i < BOX.Length; i++)
        {
            if (i == kindnum)
            {  break; }
            { if (schdulesManager.schdule == "수련")
                {
                    BOX[0].GetComponentInChildren<Text>().text = "무공수련";
                    BOX[1].GetComponentInChildren<Text>().text = "뭐뭐수련";
                    BOX[2].GetComponentInChildren<Text>().text = "사사수련3";
                }
                if (schdulesManager.schdule == "학습")
                {
                    BOX[0].GetComponentInChildren<Text>().text = "성학학습";
                    BOX[1].GetComponentInChildren<Text>().text = "무공학습";
                    BOX[2].GetComponentInChildren<Text>().text = "가요학습";
                    BOX[3].GetComponentInChildren<Text>().text = "정치학 학습";
                }
                if (schdulesManager.schdule == "휴식")
                {
                    BOX[0].GetComponentInChildren<Text>().text = "궁에서 뒹굴기";
                    BOX[1].GetComponentInChildren<Text>().text = "궁밖으로 외유 나가기";
                }
            }

        }

    }
    public void schedulebtKinds(string btName)
    {
        switch (btName)
        {

        }
    }
}
