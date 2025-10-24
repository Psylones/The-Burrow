using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {


        if (movement.NotInConversation)
        {
            float horizontal = Input.GetAxis("Horizontal");


            Vector2 moveDirection = (Vector2.right * horizontal);
            moveDirection *= speed * Time.deltaTime;


            rb.linearVelocity = moveDirection;

        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }


    }
}
