using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
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
