using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{


    [SerializeField] string Scene;//Loads this certain scene
    public void StartGame()
    {

       
        SceneManager.LoadScene(Scene);
        Debug.Log("Entering the Burrow");
    }

    public void ReturnToMain()
    {


        SceneManager.LoadScene(Scene);
        Debug.Log("Going Home");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Goodbye");

    }

    
}
