using UnityEngine;



public class Movement : MonoBehaviour
{
    public bool NotInConversation; //Changes to false when talking to a character so Bec is unable to move when dialogue is on screen
    [SerializeField] int playerSpeed;
   public Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NotInConversation = true;
    }

 


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && NotInConversation)
        {
            transform.position += new Vector3(0.01f * playerSpeed, 0, 0 );
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.A) && NotInConversation)
        {
            transform.position += new Vector3(-0.01f * playerSpeed, 0, 0 );
            anim.SetBool("IsBackwards", true);
        }
        else
        {
            anim.SetBool("IsBackwards", false);
        }



    }
}
