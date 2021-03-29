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
    int year = 1807;
    int month = 01;
    int day = 01;
    #endregion
    #region �������ͽ�
    int ps = 10;
    int tlp = 10;
    int gorce = 10;
    int decreasing = 10;
    int Politics = 10;
    int Charm = 10;
    int Karma = 10;
    int Fatigue = 10;
    #endregion
    #region ��
    int money = 1000;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
