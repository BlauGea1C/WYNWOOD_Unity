using Cinemachine;
using UnityEngine;

public class PROVES : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float LookSpeed = 2f;
    public float Gravity = -9.8f;

    float ySpeed;
    float xRotation = 0f;

    Vector3 moveDirection;
    Vector3 moveVelocity;

    CharacterController controller;
    Camera playerCamera;

    //public InventoryManager inventoryManager;
    public CinemachineVirtualCamera virtualCam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;

        if (virtualCam == null)
        {
            Debug.LogError("Cinemachine Virtual Camera not assigned!");
        }

       /* if (inventoryManager == null)
        {
            Debug.LogError("Inventory Manager not assigned!");
        }*/

        // Oculta el cursor al inicio del juego
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       /* if (!inventoryManager.IsInventoryOpen())
        {
            MovePlayer();
            LookAround();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryManager.ToggleInventoryUI();
            bool inventoryIsOpen = inventoryManager.IsInventoryOpen();

            if (inventoryIsOpen)
            {
                Cursor.lockState = CursorLockMode.None;  // Si el inventario está abierto, el cursor se desbloquea
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;  // Si el inventario está cerrado, el cursor se bloquea
            }

            // Mostrar o esconder el cursor según el estado del inventario
            Cursor.visible = inventoryIsOpen;
        }*/
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection);

        ApplyGravity();

        moveVelocity = moveDirection * MoveSpeed;
        moveVelocity.y = ySpeed;

        controller.Move(moveVelocity * Time.deltaTime);
    }

    void ApplyGravity()
    {
        if (controller.isGrounded)
        {
            ySpeed = -1f;
        }
        else
        {
            ySpeed += Gravity * Time.deltaTime;
        }
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * LookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * LookSpeed;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        virtualCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
