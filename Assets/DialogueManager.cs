using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class dialouguemanager : MonoBehaviour
{
        

        [SerializeField] private GameObject dialogueParent;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private Button option1Button;
        [SerializeField] private Button option2Button;
        [SerializeField] private Button option3Button;
        [SerializeField] private Button option4Button;
    
        [SerializeField] private float typingSpeed = 0.05f;
        [SerializeField] private float turnSpeed = 2f;

        private List<dialogueString> dialogueList;

        [Header("Player")]
        [SerializeField] private FirstPersonMovement player;
      

        public int currentDialogueIndex = 0;

        public void Start()
        {
            dialogueParent.SetActive(false);
           

        }

        
        public void DialogueStart(List<dialogueString> textToPrint, Transform NPC)
        {
            dialogueParent.SetActive(true);
            player.enabled = false;
        

           

            dialogueList = textToPrint;
            currentDialogueIndex = 0;

            DisableButtons();

            StartCoroutine(PrintDialogue());

        }

        public void DisableButtons()
        {
            option1Button.interactable = false;
            option2Button.interactable = false;
            option3Button.interactable = false;
            option4Button.interactable = false;



            option1Button.GetComponentInChildren<TMP_Text>().text = "No Option";
            option2Button.GetComponentInChildren<TMP_Text>().text = "No Option";
            option3Button.GetComponentInChildren<TMP_Text>().text = "No Option";
            option4Button.GetComponentInChildren<TMP_Text>().text = "No Option";



    }

        
        public bool optionSelected = false;


        public IEnumerator PrintDialogue()
        {
            while (currentDialogueIndex < dialogueList.Count)
            {
                dialogueString line = dialogueList[currentDialogueIndex];

                line.startDialogueEvent?.Invoke();

                if (line.isQuestion)
                {
                    yield return StartCoroutine(TypeText(line.text));

                    option1Button.interactable = true;
                    option2Button.interactable = true;
                    option3Button.interactable = true;
                    option4Button.interactable = true;


                    option1Button.GetComponentInChildren<TMP_Text>().text = line.answerOption1;
                    option2Button.GetComponentInChildren<TMP_Text>().text = line.answerOption2;
                    option3Button.GetComponentInChildren<TMP_Text>().text = line.answerOption3;
                    option4Button.GetComponentInChildren<TMP_Text>().text = line.answerOption4;


                    option1Button.onClick.AddListener(() => HandleOptionSelected(line.option1IndexJump));
                    option2Button.onClick.AddListener(() => HandleOptionSelected(line.option2IndexJump));
                    option3Button.onClick.AddListener(() => HandleOptionSelected(line.option3IndexJump));
                    option4Button.onClick.AddListener(() => HandleOptionSelected(line.option4IndexJump));



                yield return new WaitUntil(() => optionSelected);


                }
                else
                {
                    yield return StartCoroutine(TypeText(line.text));

                }
                line.endDialogueEvent?.Invoke();

                optionSelected = false;
            }
            DialogueStop();

        }

        public void HandleOptionSelected(int indexJump)
        {
            optionSelected = true;
            DisableButtons();

            currentDialogueIndex = indexJump;

        }

        public IEnumerator TypeText(string text)
        {
            dialogueText.text = "";
            foreach (char letter in text.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            if (!dialogueList[currentDialogueIndex].isQuestion)
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            }

            if (dialogueList[currentDialogueIndex].isEnd)
                DialogueStop();

            currentDialogueIndex++;

        }

        public void DialogueStop()
        {
            StopAllCoroutines();
            dialogueText.text = "";
            dialogueParent.SetActive(false);

            dialogueParent.SetActive(false);
            player.enabled = true;
           
        }
    }

