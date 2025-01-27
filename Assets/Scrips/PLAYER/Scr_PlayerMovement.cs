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

    // Variables para la c�mara virtual de Cinemachine
    public CinemachineVirtualCamera virtualCam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;

        if (virtualCam == null)
        {
            Debug.LogError("Cinemachine Virtual Camera not assigned!");
        }
    }

    void Update()
    {
        // Movimiento
        MovePlayer();

        // Rotaci�n de la c�mara
        LookAround();
    }

    void MovePlayer()
    {
        // Recibe Inputs (teclas de movimiento)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection); // Movimiento basado en la orientaci�n del jugador

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
        // Movimiento de la c�mara (mirar alrededor)
        float mouseX = Input.GetAxis("Mouse X") * LookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * VerticalLookSpeed;

        // Rotaci�n del jugador en el eje X (izquierda/derecha)
        transform.Rotate(Vector3.up * mouseX);

        // Rotaci�n de la c�mara en el eje Y (arriba/abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita la rotaci�n vertical de la c�mara
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // En una Cinemachine Virtual Camera no se maneja como en una FreeLook, pero la c�mara seguir� al jugador autom�ticamente
        // Lo importante es que la c�mara est� atada a la jerarqu�a del jugador
    }
}
