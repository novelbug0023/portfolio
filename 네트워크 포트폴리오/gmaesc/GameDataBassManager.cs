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
    #region ������
    public bool firstGame = true;

    #endregion
    #region ��¥
    public int year = 1483;
    public int month = 11;
    public int day = 23;
    #endregion
    #region �������ͽ�
    public int ps = 10;
    public int tlp = 10;
    public int gorce = 10;
    public int decreasing = 10;
    public int Politics = 10;
    public int Charm = 10;
    public int Karma = 10;
    public int Fatigue = 10;
    #endregion
    #region ��
    public int money = 1000;
    #endregion
    #region ������
    public items[] Items;
    #endregion
    #region �̱���
    private static GameDataBassManager instance = null;
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
