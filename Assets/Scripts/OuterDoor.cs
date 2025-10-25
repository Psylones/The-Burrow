using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OuterDoor : MonoBehaviour
{
    [SerializeField] BoxCollider DoorCollider; 
    [SerializeField] TextMeshProUGUI DoorText; //appears if player is in the door collider
    public bool DoorEnterable; //turns to true if player is in the door collider
    [SerializeField] string Scene; //determines where the door leads
    public bool Inside; //changes to true when in Inside scene
    public GameObject Bec; //the player character

    void Start()
    {
        DoorEnterable = false;
        DoorText.enabled = false;
        DontDestroyOnLoad(this.gameObject); //allows for the player teleportation to occur
        Inside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoorEnterable && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(Scene);
            Inside = true;
            Debug.Log("Entering Inside");
        }
        
        if (Inside)
        {
            IsInside(); 
            Inside = false;
            DoorEnterable = false;
        }
    }
    private void OnTriggerEnter(Collider DoorCollider)
    {
        if (DoorText != null)
        {
            DoorText.enabled = true;
        }

        DoorEnterable = true;

    }

    private void OnTriggerExit(Collider DoorCollider)
    {
        if (DoorText != null)
        {
            DoorText.enabled = false;
        }
        DoorEnterable = false;

    }
    public void IsInside()
    {
        GameObject Bec = GameObject.Find("BecInside");
        Bec.transform.position = new Vector3(-21, -3.83f, 4.3f);
    }
}
