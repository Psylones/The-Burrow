using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI nameText; //text that displays character name
    [SerializeField] TextMeshProUGUI dialogueText; //text that displays dialogue
    [SerializeField] Movement movement; //script
    [SerializeField] GrandpaDialogue grandpaDialogue; //script
    [SerializeField] TorchBeforeEnter torchBeforeEnter; //script
    [SerializeField] GameObject torchUI; //UI inventory item
    [SerializeField] GameObject lightCircle; //light GameObject
    [SerializeField] string Scene; //scene to change to
    private Queue<string> grandpaWords; //grandpa's dialogue lines
    public bool HasSpokenBefore; //turns to true after talking with Grandpa for the first time
    public bool QuestStart; //turns to true after talking with Grandpa for the first time
    [SerializeField] TextMeshProUGUI next; //text saying which button to continue dialogue
  
    void Start()
    {
        grandpaWords = new Queue<string>(); //creates the queue
        nameText.enabled = false;
        dialogueText.enabled = false;
        torchUI.SetActive(false);
        lightCircle.SetActive(false);
        HasSpokenBefore = false;
        QuestStart = false;
        next.enabled = false;
    }

    public void StartGrandpa(DialogueG dialogueG) //Grandpa's first round of dialogue

    {
        grandpaDialogue.InGrandpaRange = true; //Stops character movement
        Debug.Log("Starting conversation with " + dialogueG.characterName);
        next.enabled = true; //text that says how to go to next dialogue
        nameText.enabled = true;//The character name text
        dialogueText.enabled = true; //The dialogue lines
        nameText.text = dialogueG.characterName; //Puts the characters name in the name text box
        grandpaWords.Clear();//clears the dialogue box

        foreach (string sentence in dialogueG.sentences)
        {
            grandpaWords.Enqueue(sentence); //queues Grandpa's dialogue to be displayed
        }
        DisplayNextSentence();
    }

    public void EndGrandpa(DialogueG dialogueG) //Grandpa's second round of dialogue
    {
        grandpaDialogue.InGrandpaRange = true;
        Debug.Log("Starting conversation with " + dialogueG.characterName);
        next.enabled = true;
        nameText.enabled = true;
        dialogueText.enabled = true;
        nameText.text = dialogueG.characterName;
        grandpaWords.Clear();

        foreach (string secondSentence in dialogueG.secondSentences)
        {
            grandpaWords.Enqueue(secondSentence);
        }
        DisplaySecondDialogue();
    }

    public void DisplayNextSentence()
    {
        if (grandpaWords.Count == 0) //no sentences remain
        {
            EndDialogue();
            return;
        }  
        //displays the next sentence
        string sentence = grandpaWords.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    public void DisplaySecondDialogue()
    {
        if (grandpaWords.Count == 0) //goes to EndGame when no more dialogue to be said
        {
            EndGame();
            return;
        }
        //displays the next sentence
        string secondSentence = grandpaWords.Dequeue();
        dialogueText.text = secondSentence;
        Debug.Log(secondSentence);
    }

    void Update() 
    {
        if (!grandpaDialogue.InGrandpaRange) //won't play any dialogue unless in Grandpa collider
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grandpaDialogue.InGrandpaRange && movement.NotInConversation != true && !GrandpaDialogue.QuestComplete)
        {
            DisplayNextSentence(); //plays sentences

        }
        if (Input.GetKeyDown(KeyCode.Space) && grandpaDialogue.InGrandpaRange && movement.NotInConversation != true && GrandpaDialogue.QuestComplete)
        {
            DisplaySecondDialogue(); //plays second sentences

        }
    }

    void EndDialogue() 
    {
        torchBeforeEnter.HasTorch = true; //player can now enter into the deeper caves
        nameText.enabled = false; //disables text
        dialogueText.enabled = false;//disables text
        next.enabled = false;//disables text
        grandpaDialogue.InGrandpaRange = false;
        torchUI.SetActive(true); //adds torch to inventory
        lightCircle.SetActive(true);//turns on the light GameObject so the player lights up the walls of the deeper caves
        movement.ConversationOver(); //allows the player to move again
        HasSpokenBefore = true; //stops the dialogue from playing again when re entering the colldier
        QuestStart = true; //acknowleges that the quest has begun
        
        Debug.Log("End of conversation");
        Debug.Log("You got a torch!"); //let me know it was working before torch GameObject was added 
    }

    void EndGame() //loads the good ending screen
    {
        SceneManager.LoadScene(Scene);
        Debug.Log("Thanks For Playing");
    }
}
