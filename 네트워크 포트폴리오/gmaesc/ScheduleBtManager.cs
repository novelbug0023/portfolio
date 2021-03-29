using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleBtManager : MonoBehaviour
{
    #region �̱���
    private static ScheduleBtManager instance = null;
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
            case "���":
                //schdulesManager

                break;
            case "�ʱ�ȭ":
                //schdulesManager

                break;
            case "����":

                break;
            case "����":
                schdulesManager.schdule = btName;
                kindnum = 3;
                BOX = new GameObject[kindnum];
                make();


                //schdulesKinds = new GameObject[3];
                //schdulesManager.schdule = btName;
                break;
            case "�н�":
                schdulesManager.schdule = btName;
                kindnum = 4;
                BOX = new GameObject[kindnum];
                make();


                //schdulesKinds = new GameObject[4];
                //schdulesManager.schdule = btName;
                break;
            case "�޽�":
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
        Debug.Log("������ ����");
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
            { if (schdulesManager.schdule == "����")
                {
                    BOX[0].GetComponentInChildren<Text>().text = "��������";
                    BOX[1].GetComponentInChildren<Text>().text = "��������";
                    BOX[2].GetComponentInChildren<Text>().text = "������3";
                }
                if (schdulesManager.schdule == "�н�")
                {
                    BOX[0].GetComponentInChildren<Text>().text = "�����н�";
                    BOX[1].GetComponentInChildren<Text>().text = "�����н�";
                    BOX[2].GetComponentInChildren<Text>().text = "�����н�";
                    BOX[3].GetComponentInChildren<Text>().text = "��ġ�� �н�";
                }
                if (schdulesManager.schdule == "�޽�")
                {
                    BOX[0].GetComponentInChildren<Text>().text = "�ÿ��� �߱���";
                    BOX[1].GetComponentInChildren<Text>().text = "�ù����� ���� ������";
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
