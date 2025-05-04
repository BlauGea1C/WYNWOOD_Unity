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

    // Objeto de la mira
    public GameObject mira;

    public GameObject MapaUI; // UI del mapa

    public GameObject PausaMenu;

    public AudioSource audioInveatrio;
    public AudioSource audioMapa;
    public AudioSource audioPisadas;

    /*void Start()
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

        // Bloqueamos el cursor sólo si el tutorial NO está activo
        GameObject tutorialCanvas = GameObject.Find("CanvasTutorial");
        if (tutorialCanvas != null && tutorialCanvas.activeSelf)
        {
            LockCursor(false); // Desbloquea el cursor
            mira.SetActive(false);
        }
        else
        {
            LockCursor(true);
        }
    }*/

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;

        if (virtualCam == null) { 
            Debug.LogError("Cinemachine Virtual Camera not assigned!");
        }

        if (inventoryManager == null)
        {
            Debug.LogError("Inventory Manager not assigned!");
         }

        //LockCursor(true);
    }

    void Update()
    {
        // Movimiento y rotación solo si el inventario no está abierto
        if (!inventoryManager.InventoryUI.activeSelf)
        {
            MovePlayer();
            LookAround();
            mira.SetActive(true);
        }

     

        // Detecta cuando el jugador presiona la tecla E para abrir/cerrar el inventario
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioInveatrio.Play();
            if (inventoryManager.isRawImageOpen)
            {
                inventoryManager.DisableRawImage();
            }
            else
            {
                inventoryManager.ToggleInventoryUI();
            }

            LockCursor(!inventoryManager.InventoryUI.activeSelf);
            mira.SetActive(!inventoryManager.InventoryUI.activeSelf);
        }

        // Detecta cuando el jugador presiona la tecla M para abrir/cerrar el mapa
        if (Input.GetKeyDown(KeyCode.M))
        {
                audioMapa.Play();
            if (MapaUI != null)
            {
                MapaUI.SetActive(!MapaUI.activeSelf);
                
            }

            LockCursor(!MapaUI.activeSelf);
            mira.SetActive(!MapaUI.activeSelf);
        }

        // Detecta cuando el jugador presiona la tecla M para abrir/cerrar el mapa
        if (Input.GetKeyDown(KeyCode.P))
        {
            audioInveatrio.Play();
            if (PausaMenu != null)
            {
                PausaMenu.SetActive(!PausaMenu.activeSelf);

            }

            LockCursor(!PausaMenu.activeSelf);
            mira.SetActive(!PausaMenu.activeSelf);
        }
    }

    void MovePlayer()
    {
        audioPisadas.Play();
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection);

        ApplyGravity();

        moveVelocity = moveDirection * MoveSpeed;
        moveVelocity.y = ySpeed;

        controller.Move(moveVelocity * Time.deltaTime);

        bool isMoving = horizontalInput != 0 || verticalInput != 0;

        if (isMoving && controller.isGrounded)
        {
            if (!audioPisadas.isPlaying)
            {
                audioPisadas.Play();
            }
        }
        else
        {
            if (audioPisadas.isPlaying)
            {
                audioPisadas.Stop();
            }
        }

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

}