using UnityEngine;

public class Music : MonoBehaviour
{
    public static bool MusicStart;
    void Start()
    {
        MusicStart = true;
    }
    void Update()
    {
        if (MusicController.gameOver && !MusicStart)
        {
             Destroy(this.gameObject);
        }
       DontDestroyOnLoad(this.gameObject);
    }
}
