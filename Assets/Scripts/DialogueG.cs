using UnityEngine;

[System.Serializable]
public class DialogueG
{
    public string characterName;


    [TextArea(3,10)]
    public string[] sentences;

    [TextArea(3, 10)]
    public string[] secondSentences;
}
