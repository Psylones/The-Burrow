using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueManagerCreature : MonoBehaviour
{
    [SerializeField] string Scene;//Loads this certain scene
    [SerializeField] TextMeshProUGUI nameText; //displays character name
    [SerializeField] TextMeshProUGUI dialogueText; //displays character dialogue
    [SerializeField] Movement movement; //Bec's script
    [SerializeField] CreatureDialogue creatureDialogue; //Creature's script
    [SerializeField] GameObject ScaredyBat; //scared character sprite
    [SerializeField] GameObject Bec; //the main character game object
    public Animator anim; //the scaredy bat sprite animator
    [SerializeField] TextMeshProUGUI next; //text saying how to continue dialogue
    private Queue<string> creatureWords; //Creature's dialogue lines

    void Start()
    {
        creatureWords = new Queue<string>(); //creates queue
        nameText.enabled = false;
        dialogueText.enabled = false;
        next.enabled = false;
    }

    public void StartCreature(DialogueG dialogueG) //begins Creature dialogue
    {
        creatureDialogue.InCreatureRange = true; //stops player movement
        Debug.Log("Starting conversation with " + dialogueG.characterName);
        Bec.SetActive(false); //disables the regualar character sprite
        ScaredyBat.SetActive(true); //enables the scared sprite in the regular one's place
        anim.SetBool("IsScared", true); //turns scared sprite from idle to animated
        next.enabled = true;
        nameText.enabled = true;
        dialogueText.enabled = true;
        nameText.text = dialogueG.characterName;
        creatureWords.Clear(); //clears any previous dialogue

        foreach (string sentence in dialogueG.sentences)
        {
            creatureWords.Enqueue(sentence);  //adds the creature's dialogue to the queue
        }
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (creatureWords.Count == 0) //no sentences remain
        {
            EndDialogue();
            return;
        }
        //displays the next sentence
        string sentence = creatureWords.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    void Update()
    {
        if (!creatureDialogue.InCreatureRange) //won't play any dialogue unless turned to true by entering Creature collider
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && creatureDialogue.InCreatureRange && movement.NotInConversation != true)
        {
            DisplayNextSentence(); //plays sentences
        }
    }

    void EndDialogue() //goes to bad ending screen
    {
        SceneManager.LoadScene(Scene);
        Debug.Log("Exiting the Burrow");
    }
}
