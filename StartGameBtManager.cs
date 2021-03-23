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
            case "시작":
                    SceneManager.LoadScene("GameScene_1");
                break;
            case "불러오기":
                break;
            case "옵션":
                break;
            case "나가기":
                break;
        }
    }
    public void popupbt(string startpopupbt)
    {
        switch (startpopupbt)
        {
            case "네":
                break;
            case "아니오":
                break;
            
        }
    }
}
