using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<dialogueString> dialogueStrings = new List<dialogueString>();
    [SerializeField] private Transform NPCTransform;

    private bool hasSpoken = false;

    public GameObject myGameObject;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered!");

        if (other.CompareTag("Player") )
        {
            Debug.Log("player entered!");
          
            other.gameObject.GetComponent<dialouguemanager>().DialogueStart(dialogueStrings, NPCTransform);
            
        }
        gameObject.SetActive(false);
    }
}

[System.Serializable]
public class dialogueString
{
    public string text; // text npc says 
    public bool isEnd; // if line is final line for convo

    [Header("branch")]
    public bool isQuestion;
    public string answerOption1;
    public string answerOption2;
    public string answerOption3;
    public string answerOption4;
   
    public int option1IndexJump;
    public int option2IndexJump;
    public int option3IndexJump;
    public int option4IndexJump;
    

    [Header("Triggered Events")]
    public UnityEvent startDialogueEvent;
    public UnityEvent endDialogueEvent;

}