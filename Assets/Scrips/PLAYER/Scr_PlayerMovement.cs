using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerMovement : MonoBehaviour
{
    /*  public float MoveSpeed = 5f;
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

          // Asegurar que el cursor está bloqueado al iniciar el juego
          LockCursor(true);
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
              if (MapaUI != null)
              {
                  MapaUI.SetActive(!MapaUI.activeSelf);
              }

              LockCursor(!MapaUI.activeSelf);
              mira.SetActive(!MapaUI.activeSelf);
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

      //NUEVA FUNCIÓN DE TELETRANSPORTE
      public void TeleportTo(Transform targetLocation)
      {
          if (targetLocation != null)
          {
              Debug.Log("Teletransportando a: " + targetLocation.position);

              CharacterController controller = GetComponent<CharacterController>();
              if (controller != null)
              {
                  controller.enabled = false; // Desactiva el CharacterController antes de mover
                  transform.position = targetLocation.position;
                  controller.enabled = true; // Reactiva el CharacterController después del movimiento
              }
              else
              {
                  transform.position = targetLocation.position;
              }

              Debug.Log("Nueva posición del jugador: " + transform.position);
          }
          else
          {
              Debug.LogError("El punto de teletransporte no está asignado.");
          }
      }
  }*/
    /*  public float MoveSpeed = 5f;
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

          // Asegurar que el cursor está bloqueado al iniciar el juego
          LockCursor(true);
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
              if (MapaUI != null)
              {
                  MapaUI.SetActive(!MapaUI.activeSelf);
              }

              LockCursor(!MapaUI.activeSelf);
              mira.SetActive(!MapaUI.activeSelf);
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

      // Nueva función de teletransporte
      public void TeleportTo(Transform targetLocation)
      {
          if (targetLocation != null)
          {
              Debug.Log("Teletransportando a: " + targetLocation.position);

              if (controller == null)
              {
                  Debug.LogError("X CharacterController no encontrado en el jugador.");
                  return;
              }

              controller.enabled = false;  // Desactivar CharacterController

              // Verificación adicional para saber si la posición del objetivo es válida
              if (targetLocation != null)
              {
                  // Desplazamiento de 0.5 unidades hacia arriba para evitar que el jugador se quede pegado al suelo
                  Vector3 newPosition = targetLocation.position + Vector3.up * 0.5f;

                  // Mover al jugador a la nueva posición
                  transform.position = newPosition;
                  Debug.Log("Posición final del teletransporte: " + newPosition);
              }

              controller.enabled = true;   // Reactivar CharacterController

              ySpeed = 0; // Resetear velocidad vertical para evitar que el jugador caiga inmediatamente

              Debug.Log("Nueva posición del jugador después de teletransportarse: " + transform.position);
          }
          else
          {
              Debug.LogError("X El punto de teletransporte no está asignado.");
          }
      }
  }*/

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

        // Asegurar que el cursor está bloqueado al iniciar el juego
        LockCursor(true);
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
            if (MapaUI != null)
            {
                MapaUI.SetActive(!MapaUI.activeSelf);
            }

            LockCursor(!MapaUI.activeSelf);
            mira.SetActive(!MapaUI.activeSelf);
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

}