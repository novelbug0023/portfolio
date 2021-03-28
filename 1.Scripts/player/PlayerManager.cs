using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    players Players;
    public float currHP;
    public float initHP;
    public Image hpbar;
    public float currMP;
    public float initMP;
    public Image mpbar;
    public float currSP;
    public float initSP;
    public Image spbar;
    // Start is called before the first frame update
    void Start()
    {
        Players = GetComponentInParent<players>();
        StartCoroutine(this.AutoHealing());
        StartCoroutine(this.AutoMP());
        StartCoroutine(this.AutoSP());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AutoHealing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.11f);
            if (currHP < initHP)
            {
                currHP += 2;
                hpbar.fillAmount = currHP / initHP;
            }
        }

    }
    IEnumerator AutoMP()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.11f);
            if (currMP < initMP)
            {
                currMP += 2;
                mpbar.fillAmount = currMP / initMP;
            }
        }

    }
    IEnumerator AutoSP()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.11f);
            if (currSP < initSP)
            {
                currHP += 2;
                spbar.fillAmount = currSP / initSP;
            }
        }

    }
}
