using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scr_Teleport : MonoBehaviour
{
    public GameObject player;
    private CharacterController playerController;

    public Transform teleportPoint1;
    public Button CasaPlayer;
    public Transform teleportPoint2;
    public Button Coffee;
    public Transform teleportPoint3;
    public Button casaLia;
    public Transform teleportPoint4;
    public Button Comi;
    public Transform teleportPoint5;
    public Button Escuela;
    public Transform teleportPoint6;
    public Button casaNoah;

    void Start()
    {
        if (player != null)
        {
            playerController = player.GetComponent<CharacterController>();
        }

        // Desactivar botones hasta que se desbloqueen
        Coffee.interactable = false;
        casaLia.interactable = false;
        Comi.interactable = false;
        Escuela.interactable = false;
        casaNoah.interactable = false;
    }

    public void TeleportTo(Transform targetLocation)
    {
        if (targetLocation != null && player != null)
        {
            Debug.Log("Teletransportando a: " + targetLocation.position);

            if (playerController != null)
            {
                playerController.enabled = false; // Deshabilitar CharacterController antes de mover
            }

            // Teletransportar al jugador
            player.transform.position = targetLocation.position;
            player.transform.rotation = targetLocation.rotation; // Mantener rotación

            if (playerController != null)
            {
                playerController.enabled = true; // Volver a habilitar el CharacterController
            }

            Debug.Log("Nueva posición del jugador: " + player.transform.position);
        }
        else
        {
            Debug.LogError("El punto de teletransporte o el jugador no está asignado.");
        }
    }

    // Métodos de teletransporte
    public void TeleportTo1() { TeleportTo(teleportPoint1); }
    public void TeleportTo2() { TeleportTo(teleportPoint2); }
    public void TeleportTo3() { TeleportTo(teleportPoint3); }
    public void TeleportTo4() { TeleportTo(teleportPoint4); }
    public void TeleportTo5() { TeleportTo(teleportPoint5); }
    public void TeleportTo6() { TeleportTo(teleportPoint6); }

    // Métodos para desbloquear botones
    public void DesbloquearBoton2() { Coffee.interactable = true; }
    public void DesbloquearBoton3() { casaLia.interactable = true; }
    public void DesbloquearBoton4() { Comi.interactable = true; }
    public void DesbloquearBoton5() { Escuela.interactable = true; }
    public void DesbloquearBoton6() { casaNoah.interactable = true; }
}