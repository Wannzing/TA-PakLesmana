using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 6f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    [Header("Ground Check")]
    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("UI")]
    public GameObject endScreen;

    private float fallThreshold = 20f;
    private float highestY;
    private CharacterController controller;
    private Vector3 velocity;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        endScreen.SetActive(false);
        highestY = transform.position.y;
    }

    private void Update()
    {
        GroundCheck();
        MovePlayer();
        ApplyGravity();
        GameOver();
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void GameOver()
    {
        if (transform.position.y > highestY)
        {
            highestY = transform.position.y;
        }

        if (transform.position.y < highestY - fallThreshold)
        {
            endScreen.SetActive(true);
        }
    }
}
