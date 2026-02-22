using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    Vector2 moveInput;

    void Update()
    {
        GroundCheck();

        if (MenuManager.Instance != null && MenuManager.Instance.IsMenuOpen)
            return;

#if UNITY_STANDALONE || UNITY_WEBGL
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Move(new Vector2(x, z));

        if (Input.GetButtonDown("Jump"))
            Jump();
#endif

        ApplyMovement();
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
    }

    public void Move(Vector2 input)
    {
        moveInput = input;
    }

    void ApplyMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (!isGrounded) return;

        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}