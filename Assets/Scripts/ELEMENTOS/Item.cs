using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cuando vayamos a Assets > Create > Item > Create New Item, se creará un nuevo archivo de tipo Item en el proyecto.
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    // Información que tienen los ítems
     public string id; // ID único para cada ítem
     public string itemsName;
     public Sprite ItemIcono;
     public GameObject Objeto3D;
     public string loc; // Orden Botones
     public bool Llave = false; // Si es una llave   
     public bool LlavesPuerta = false;
     public bool LlavesCaja = false;
     public string mensajes;


}
    