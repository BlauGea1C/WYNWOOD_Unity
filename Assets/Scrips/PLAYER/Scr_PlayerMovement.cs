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

    // Variables para la cámara virtual de Cinemachine
    public CinemachineVirtualCamera virtualCam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;

        if (virtualCam == null)
        {
            Debug.LogError("Cinemachine Virtual Camera not assigned!");
        }

        // Verifica que el script de inventario esté asignado
        if (inventoryManager == null)
        {
            Debug.LogError("Inventory Manager not assigned!");
        }
    }

    void Update()
    {
        // Movimiento
        MovePlayer();

        // Rotación de la cámara
        LookAround();

        // Detecta cuando el jugador presiona la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Llama a la función para alternar la visibilidad del inventario
            inventoryManager.ToggleInventoryUI();
        }
    }

    void MovePlayer()
    {
        // Recibe Inputs (teclas de movimiento)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection); // Movimiento basado en la orientación del jugador

        // Aplica gravedad
        ApplyGravity();

        // Calculamos la velocidad de movimiento
        moveVelocity = moveDirection * MoveSpeed;
        moveVelocity.y = ySpeed;

        // Movimiento del jugador
        controller.Move(moveVelocity * Time.deltaTime);
    }

    void ApplyGravity()
    {
        if (controller.isGrounded)
        {
            ySpeed = -1f; // No se queda flotando
        }
        else
        {
            ySpeed += Gravity * Time.deltaTime;
        }
    }

    void LookAround()
    {
        // Obtener el movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * LookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * LookSpeed;

        // Rotación horizontal (y del jugador)
        transform.Rotate(Vector3.up * mouseX);

        // Rotación vertical (cámara)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);  // Limitar la rotación vertical para evitar voltear la cámara

        virtualCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // Aplicar rotación vertical
    }
}
