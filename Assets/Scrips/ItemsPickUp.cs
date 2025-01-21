using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsP : MonoBehaviour
{
    public Item Item;

    //Recoge el �tem
    void Pickup()
    {
        // Llama al m�todo Add() del InventoryManager para a�adir el �tem al inventario
        InventoryManager.Instance.Add(Item);

        // Destruye el objeto en la escena, ya que el �tem fue recogido
        Destroy(gameObject);

    }
    //El jugador hace clic sobre el objeto en la escena
    private void OnMouseDown()
    {
        Pickup();
    }
}
