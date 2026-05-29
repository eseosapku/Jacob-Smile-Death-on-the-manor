using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float mouseSpeed = 2f;
    public float gravity = -9.81f;
    private CharacterController player;
    private Camera playerCamera;
    private float verticalVelocity = 0f;
    private float playerRotation = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        MouseView();
    }

    void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = (transform.right * moveX) + (transform.forward * moveZ);
        Vector3 finalMove = moveDirection * playerSpeed;
        if (player.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        finalMove.y = verticalVelocity;
        player.Move(finalMove * Time.deltaTime);
    }

    void MouseView()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;
        transform.Rotate(Vector3.up * mouseX);
        playerRotation -= mouseY;
        playerRotation = Mathf.Clamp(playerRotation, -90f, 90f);
        if (playerCamera != null)
        {
            playerCamera.transform.localRotation = Quaternion.Euler(playerRotation, 0f, 0f);
        }
    }
}

