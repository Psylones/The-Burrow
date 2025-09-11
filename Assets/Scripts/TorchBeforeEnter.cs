using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEditor.Rendering;
using TMPro;

public class TorchBeforeEnter : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public DialogueG dialogueG;
    public DialogueManager dialogueManager;
    public bool HasTorch;
    public BoxCollider entrance;
    public BoxCollider entranceDetect;
    private Queue<string> denyText;
    public Movement movement;
    public bool GettingDenied;
    internal readonly bool Gettingdenied;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HasTorch = false;
        denyText = new Queue<string>();
        nameText.enabled = false;
        dialogueText.enabled = false;
        GettingDenied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasTorch)
        {
            entrance.enabled = false;
            entranceDetect.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && HasTorch != true && GettingDenied)
        {
            CloseDialogue();

        }

    }


        public void OnTriggerEnter(UnityEngine.Collider entranceDetect)
    {
        Debug.Log("this is working");
        DenyAccess();
    }

    public void OnTriggerExit(UnityEngine.Collider entranceDetect)
    {
        Debug.Log("Leaving trigger");
        GettingDenied = false ;
    }

    public void DenyAccess()
    {
        nameText.enabled = true;
        dialogueText.enabled = true;
        nameText.text = dialogueG.characterName;
        GettingDenied = true;
        movement.NotInConversation = false;
        denyText.Clear();

        foreach (string sentence in dialogueG.sentences)
        {
            denyText.Enqueue(sentence);
            dialogueText.text = sentence;

        }

    }

    public void CloseDialogue()
    {
        GettingDenied = false;
        nameText.enabled = false;
        dialogueText.enabled = false;
        movement.ConversationOver();
        Debug.Log("and stay out, loser");
       

    }
}
