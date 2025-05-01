using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cuando vayamos a Assets > Create > Item > Create New Item, se crear� un nuevo archivo de tipo Item en el proyecto.
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    // Informaci�n que tienen los �tems
     public string id; // ID �nico para cada �tem
     public string itemsName;
     public Sprite ItemIcono;
     public GameObject Objeto3D;
     public string loc; // Orden Botones
     public bool Llave = false; // Si es una llave   
     public bool LlavesPuerta = false;
     public bool LlavesCaja = false;
     public string mensajes;


}
    