using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBtManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startbtManager(string btManager)
    {
        switch (btManager)
        {
            case "����":
                    SceneManager.LoadScene("GameScene_1");
                break;
            case "�ҷ�����":
                break;
            case "�ɼ�":
                break;
            case "������":
                break;
        }
    }
    public void popupbt(string startpopupbt)
    {
        switch (startpopupbt)
        {
            case "��":
                break;
            case "�ƴϿ�":
                break;
            
        }
    }
}
