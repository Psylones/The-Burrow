using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManagerCreature : MonoBehaviour
{
    [SerializeField] string Scene;//Loads this certain scene
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Movement movement;
    public CreatureDialogue creatureDialogue;

    private Queue<string> creatureWords;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creatureWords = new Queue<string>();
        nameText.enabled = false;
        dialogueText.enabled = false;
    }

    public void StartCreature(DialogueG dialogueG)

    {

        creatureDialogue.InCreatureRange = true;
        movement.NotInConversation = false;
        Debug.Log("Not in Conversation = False");
        Debug.Log("Starting conversation with " + dialogueG.characterName);

        nameText.enabled = true;
        dialogueText.enabled = true;
        nameText.text = dialogueG.characterName;

        creatureWords.Clear();

        foreach (string sentence in dialogueG.sentences)
        {
            creatureWords.Enqueue(sentence);


        }

        DisplayNextSentence();

    }


    public void DisplayNextSentence()
    {
        if (creatureWords.Count == 0)

        {
            EndDialogue();
            movement.NotInConversation = false;
            return;
        }


        string sentence = creatureWords.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);








    }

    void Update()
    {

        if (!creatureDialogue.InCreatureRange)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && creatureDialogue.InCreatureRange && movement.NotInConversation != true)
        {
            DisplayNextSentence();

        }
    }

    void EndDialogue()
    {
        SceneManager.LoadScene(Scene);
        Debug.Log("Exiting the Burrow");
    }

}
