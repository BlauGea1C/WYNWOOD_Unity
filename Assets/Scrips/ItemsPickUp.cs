using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsP : MonoBehaviour
{
    public Item Item;

    //Recoge el ítem
    void Pickup()
    {
        // Llama al método Add() del InventoryManager para añadir el ítem al inventario
        InventoryManager.Instance.Add(Item);

        // Destruye el objeto en la escena, ya que el ítem fue recogido
        Destroy(gameObject);

    }
    //El jugador hace clic sobre el objeto en la escena
    private void OnMouseDown()
    {
        Pickup();
    }
}
