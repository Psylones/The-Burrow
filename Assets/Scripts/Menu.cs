using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] string burrowScene;//Loads this certain scene
    public void StartGame()
    {


        SceneManager.LoadScene(burrowScene);
        Debug.Log("Entering the Burrow");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Goodbye");

    }
}
