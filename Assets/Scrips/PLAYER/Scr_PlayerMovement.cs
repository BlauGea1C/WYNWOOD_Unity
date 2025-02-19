using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float LookSpeed = 2f;
    public float VerticalLookSpeed = 2f;
    public float Gravity = -9.8f;

    float ySpeed;
    float xRotation = 0f;

    Vector3 moveDirection;
    Vector3 moveVelocity;

    CharacterController controller;
    Camera playerCamera;

    // Referencia al script de inventario
    public InventoryManager inventoryManager;

    // Variables para la c�mara virtual de Cinemachine
    public CinemachineVirtualCamera virtualCam;

    //ObjetoMira
    public GameObject mira;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;

        if (virtualCam == null)
        {
            Debug.LogError("Cinemachine Virtual Camera not assigned!");
        }

        if (inventoryManager == null)
        {
            Debug.LogError("Inventory Manager not assigned!");
        }

        // Asegurar que el cursor est� bloqueado al iniciar el juego
        LockCursor(true);
    }

    void Update()
    {
        // Movimiento y rotaci�n solo si el inventario no est� abierto
        if (!inventoryManager.InventoryUI.activeSelf)
        {
            MovePlayer();
            LookAround();
            mira.SetActive(true);
        }

        // Detecta cuando el jugador presiona la tecla E para abrir/cerrar el inventario
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Verificar si el RawImage est� abierto
            if (inventoryManager.isRawImageOpen)
            {
                // Si el RawImage est� abierto, primero lo cerramos
                inventoryManager.DisableRawImage();
            }
            else
            {
                // Si el RawImage no est� abierto, alternamos el inventario
                inventoryManager.ToggleInventoryUI();
            }

            // Alternar el bloqueo del cursor y la visibilidad de la mira
            LockCursor(!inventoryManager.InventoryUI.activeSelf);
            mira.SetActive(!inventoryManager.InventoryUI.activeSelf);
        }
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

    void LockCursor(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void LockMira(bool isLocked)
    {
        if (isLocked)
        {
           mira.SetActive(true);
            
        }
        else
        {
            mira.SetActive(false);
        }
    }
}
