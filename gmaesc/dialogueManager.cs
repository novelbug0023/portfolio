using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class dialogue
{
    public string[] sdialogues;
    public string dialogue_name;
    public Image charactorimage;
}
public class dialogueManager : MonoBehaviour
{
    public dialogue[] Dialogues;
    public Text dialogueText;
    public Text NameText;
    public GameObject dialogue_box;
    public GameObject dialogueNextBt;
    public int dialogueindex = 0;
    public int nextDialogue = 0;
    string sdialogue;
    // Start is called before the first frame update
    void Start()
    {
        if (GameDataBassManager.Instance.firstGame)
        {
            dialogue_box.SetActive(true);
            dialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void dialogue()
    {
        sdialogue = Dialogues[dialogueindex].sdialogues[nextDialogue];
        StartCoroutine(dialogueTime());
    }
    IEnumerator dialogueTime()
    {
        NameText.text = Dialogues[dialogueindex].dialogue_name;
        
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i <= sdialogue.Length; i++)
        {
            dialogueText.text = sdialogue.Substring(0, i);
            yield return new WaitForSeconds(0.1f);
        }
        dialogueNextBt.SetActive(true);
    }
    public void nextDialogueBt()
    {
        if (nextDialogue+1 >= Dialogues[dialogueindex].sdialogues.Length)
        {
            Debug.Log("대화 종료");
            endDialogue();
        }
        else if(nextDialogue < Dialogues[dialogueindex].sdialogues.Length)
        {
            Debug.Log("다음대화");
            dialogueNextBt.SetActive(false);
            nextDialogue++;
            dialogue();
            //StartCoroutine(dialogueTime());
        }
        
    }
    void endDialogue()
    {
        nextDialogue = 0;
        StopCoroutine(dialogueTime());
        dialogueindex++;
        dialogue_box.SetActive(false);
    }
    
}
