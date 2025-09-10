using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Movement movement;
    public GrandpaDialogue grandpaDialogue;

    private Queue<string> grandpaWords;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grandpaWords = new Queue<string>();
        nameText.enabled = false;
        dialogueText.enabled = false;
    }

    public void StartGrandpa(DialogueG dialogueG)

    {

        grandpaDialogue.InGrandpaRange = true;
        movement.NotInConversation = false;
        Debug.Log("Not in Conversation = False");
        Debug.Log("Starting conversation with " + dialogueG.characterName);

        nameText.enabled = true;
        dialogueText.enabled = true;
        nameText.text = dialogueG.characterName;

        grandpaWords.Clear();

        foreach (string sentence in dialogueG.sentences)
        {
            grandpaWords.Enqueue(sentence);


        }

        DisplayNextSentence();
       
    }


    public void DisplayNextSentence()
    {
        if (grandpaWords.Count == 0)

        {
            EndDialogue();
            movement.NotInConversation = false;
            return;
        }

        
        string sentence = grandpaWords.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);

       
            
            

       
        

    }

   void Update()
    {

        if (!grandpaDialogue.InGrandpaRange)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grandpaDialogue.InGrandpaRange && movement.NotInConversation != true)
        {
            DisplayNextSentence();

        }
    }

    void EndDialogue() 
    {
        nameText.enabled = false;
        dialogueText.enabled = false;
        grandpaDialogue.InGrandpaRange = false;
        movement.ConversationOver();
        Debug.Log("End of conversation");
        Debug.Log("Not in Conversation = " + movement.NotInConversation);
    }

}
