using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamebtManager : MonoBehaviour
{
    SchedulesystemManager schdulesManager;
    public GameObject clerender;
    // Start is called before the first frame update
    void Start()
    {
        schdulesManager = GameObject.Find("schduleManager").GetComponent<SchedulesystemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bt(string bt)
    {
        switch (bt)
        {
            case "¿œ¡§":
                clerender.SetActive(true);
                schdulesManager.StartCalendar();
                
                break;
        }
    }
}
