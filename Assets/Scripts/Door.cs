using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] BoxCollider DoorCollider;
    [SerializeField] TextMeshProUGUI DoorText;
    private bool DoorEnterable;
    [SerializeField] string Scene;
    void Start()
    {
        DoorEnterable = false;
        DoorText.enabled = false;
    }
    void Update()
    {
        if (DoorEnterable && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(Scene);
        }
    }
    private void OnTriggerEnter(Collider DoorCollider)
    {
        DoorText.enabled = true;
        DoorEnterable = true;

    }
    private void OnTriggerExit(Collider DoorCollider)
    {
        DoorText.enabled = false;
        DoorEnterable = false;
    }
}
