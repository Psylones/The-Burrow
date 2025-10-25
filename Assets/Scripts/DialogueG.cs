using UnityEngine;

[System.Serializable]
public class DialogueG
{
    public string characterName;

    [TextArea(3,10)] //gives a bigger text area
    public string[] sentences; //controls first round of dialogue

    [TextArea(3, 10)]
    public string[] secondSentences; //controls second round of dialogue
}
