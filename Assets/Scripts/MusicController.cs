using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static bool gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver = true; 

        Music.MusicStart = false;
    }
}
