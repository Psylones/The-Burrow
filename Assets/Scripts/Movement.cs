using UnityEngine;



public class Movement : MonoBehaviour
{
    public bool NotInConversation; //Changes to false when talking to a character so Bec is unable to move when dialogue is on screen
    [SerializeField] int playerSpeed;
   public Animator anim;
    [SerializeField] float speed;
    public Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NotInConversation = true;
        rb = GetComponent<Rigidbody>();
    }

 


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && NotInConversation)
       {
            
           anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.A) && NotInConversation)
        {
           
           anim.SetBool("IsBackwards", true);
       }
        else
        {
            anim.SetBool("IsBackwards", false);
        }



    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveDirection = (Vector2.right * horizontal) + (Vector2.up * vertical);
        moveDirection *= speed * Time.deltaTime;

        rb.linearVelocity = moveDirection;
    }
}
