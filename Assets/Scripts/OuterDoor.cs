using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OuterDoor : MonoBehaviour
{
    public BoxCollider DoorCollider;
    public TextMeshProUGUI DoorText;
    public bool DoorEnterable;
    [SerializeField] string Scene;
    public bool Inside;
    public GameObject Bec;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DoorEnterable = false;
        DoorText.enabled = false;
        DontDestroyOnLoad(this.gameObject);
        Inside = false;
    

    }

    // Update is called once per frame
    void Update()
    {
        if (DoorEnterable && Input.GetKeyDown(KeyCode.Space))
        {
            Inside = true;
            SceneManager.LoadScene(Scene);
            Debug.Log("Entering Inside");
           
            Bec.transform.position = new Vector3(-21, -3.83f, 4.3f);

        }
        
        if (Inside)
        {
            {
                GameObject Bec = GameObject.Find("BecInside");
                if (Bec != null)
                {
                    Bec.transform.position = new Vector3(-21, -3.83f, 4.3f);
                }
            }

        }

       
    }
    public void OnTriggerEnter(Collider DoorCollider)
    {
        DoorText.enabled = true;
        DoorEnterable = true;

    }

    public void OnTriggerExit(Collider DoorCollider)
    {
        DoorText.enabled = false;
        DoorEnterable = false;

    }
}
