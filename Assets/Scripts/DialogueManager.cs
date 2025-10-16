using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Movement movement;
    public GrandpaDialogue grandpaDialogue;
    public TorchBeforeEnter torchBeforeEnter;
    public GameObject torchUI;
    public GameObject lightCircle;
    [SerializeField] string Scene;
    private Queue<string> grandpaWords;
    public bool HasSpokenBefore;
    public bool QuestStart;
    public TextMeshProUGUI next;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grandpaWords = new Queue<string>();
        nameText.enabled = false;
        dialogueText.enabled = false;
        torchUI.SetActive(false);
        lightCircle.SetActive(false);
        HasSpokenBefore = false;
        QuestStart = false;
        next.enabled = false;
    }

    public void StartGrandpa(DialogueG dialogueG)

    {
        grandpaDialogue.InGrandpaRange = true;
        movement.NotInConversation = false;
        Debug.Log("Not in Conversation = False");
        Debug.Log("Starting conversation with " + dialogueG.characterName);
        next.enabled = true;
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

    public void EndGrandpa(DialogueG dialogueG)
    {
 grandpaDialogue.InGrandpaRange = true;
        movement.NotInConversation = false;
        Debug.Log("Not in Conversation = False");
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

    public void DisplaySecondDialogue()
    {
        if (grandpaWords.Count == 0)

        {
            EndGame();
            movement.NotInConversation = false;
            return;
        }


        string secondSentence = grandpaWords.Dequeue();
        dialogueText.text = secondSentence;
        Debug.Log(secondSentence);


    }

    void Update()
    {

        if (!grandpaDialogue.InGrandpaRange)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grandpaDialogue.InGrandpaRange && movement.NotInConversation != true && !GrandpaDialogue.QuestComplete)
        {
            DisplayNextSentence();

        }
        if (Input.GetKeyDown(KeyCode.Space) && grandpaDialogue.InGrandpaRange && movement.NotInConversation != true && GrandpaDialogue.QuestComplete)
        {
            DisplaySecondDialogue();

        }
    }

    void EndDialogue() 
    {
        torchBeforeEnter.HasTorch = true;
        nameText.enabled = false;
        dialogueText.enabled = false;
        grandpaDialogue.InGrandpaRange = false;
        torchUI.SetActive(true);
        lightCircle.SetActive(true);
        movement.ConversationOver();
        HasSpokenBefore = true;
        QuestStart = true;
        next.enabled = false;
        Debug.Log("End of conversation");
        Debug.Log("Not in Conversation = " + movement.NotInConversation);
        Debug.Log("You got a torch!");
    }

    void EndGame()
    {
        next.enabled = false;
        GemOther.treasureCollected = 0;
        SceneManager.LoadScene(Scene);
        Debug.Log("Thanks For Playing");

    }
}
