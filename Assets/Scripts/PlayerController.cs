using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject controller;
    public float playerSpeed = 5f;
    public float mouseSpeed = 2f;
    private CharacterController player;
    private Camera playerCamera;
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
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
    }

    void PlayerMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(0, 0, playerSpeed  * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(0, 0, -playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }
    }

    void MouseView()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;
        player.transform.Rotate(Vector3.up * mouseX);
        playerRotation -= mouseY;
        playerRotation = Mathf.Clamp(playerRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(playerRotation, 0f, 0f);
    }
}

